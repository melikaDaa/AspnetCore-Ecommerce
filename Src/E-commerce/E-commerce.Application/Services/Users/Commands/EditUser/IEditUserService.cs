using E_commerce.Application.Interface;
using E_commerce.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEdituserDto request);
    }
    public class EditUserService : IEditUserService
    {
        private readonly IDatabaseContext _context;

        public EditUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEdituserDto request)
        {
            var user = _context.Users.Find(request.UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.FullName = request.Fullname;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ویرایش کاربر انجام شد"
            };

        }
    }


    public class RequestEdituserDto
    {
        public long UserId { get; set; }
        public string Fullname { get; set; }
    }
}
