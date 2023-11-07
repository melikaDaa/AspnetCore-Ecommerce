using E_commerce.Application.Interface;
using E_commerce.Common.Dto;
using E_commerce.Domain.Entities.Finances;
using E_commerce.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Fainances.Commands.AddRequestPay
{
    public interface IAddRequestPayService
    {
        ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId);
    }


    public class AddRequestPayService : IAddRequestPayService
    {
        private readonly IDatabaseContext _context;
        public AddRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId)
        {
            var user = _context.Users.Find(UserId);

            var requestPay = CreateRequestPay(Amount, user);

            SaveRequestPay(requestPay);
            return CreateSuccessResult(requestPay);


        }
        //ایجاد درخواست پرداخت جدید
        private RequestPay CreateRequestPay(int amount,User user)
        {
            return new RequestPay
            {
                Amount = amount,
                Guid = Guid.NewGuid(),
                IsPay = false,
                User = user
            };
        }
        //دخیره تغیرات در دیتابیس
        private void SaveRequestPay(RequestPay requestPay)
        {
            _context.RequestPays.Add(requestPay);
            _context.SaveChanges();
        }
        // ایجاد نتیجه‌ی موفقیت با اطلاعات درخواست پرداخت
        private ResultDto<ResultRequestPayDto> CreateSuccessResult(RequestPay requestPay)
        {
            return new ResultDto<ResultRequestPayDto>
            {
                Data = new ResultRequestPayDto
                {
                    guid = requestPay.Guid,
                    Amount = requestPay.Amount,
                    Email = requestPay.User.Email,
                    RequestPayId = requestPay.Id,
                },
                IsSuccess = true
            };
        }
    }

    public class ResultRequestPayDto
    {
        public Guid guid { get; set; }
        public int Amount { get; set; }
        public string Email { get; set; }
        public long RequestPayId { get; set; }
    }
}
