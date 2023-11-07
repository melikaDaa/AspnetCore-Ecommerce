using E_commerce.Application.Interface;
using E_commerce.Common;
using E_commerce.Common.Dto;
using E_commerce.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Users.Commands.UserLogin
{
    public interface IUserLoginService
    {
        ResultDto<ResultUserloginDto> Execute(string Username, string Password);
    }

    public class UserLoginService : IUserLoginService
    {
        private readonly IDatabaseContext _context;
        public UserLoginService(IDatabaseContext context)
        {
            _context = context;
        }
        //لاگین  کاربر
        public ResultDto<ResultUserloginDto> Execute(string Username, string Password)

        {

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                return CreateErrorResult("نام کاربری و رمز عبور را وارد نمایید");
            }


            var user = GetUserByEmail(Username);

            if (user == null)
            {
                return CreateErrorResult("کاربری با این ایمیل در سایت فروشگاه کالا مارکت ثبت نام نکرده است");
            }


            if (!IsPasswordValid(user.Password, Password))
            {
                return CreateErrorResult("رمز وارد شده اشتباه است!");
            }


            var roles = "";
            foreach (var item in user.UserInRoles)
            {
                roles += $"{item.Role.Name}";
            }


            return new ResultDto<ResultUserloginDto>()
            {
                Data = new ResultUserloginDto()
                {
                    Roles = roles,
                    UserId = user.Id,
                    Name = user.FullName
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد",
            };


        }
        //دریافت نام کاربری (ایمیل(
        private User GetUserByEmail(string email)
        {
            return _context.Users
                .Include(p => p.UserInRoles)
                .ThenInclude(p => p.Role)
                .FirstOrDefault(p => p.Email.Equals(email) && p.IsActive);
        }
        //بررسی پسورد معتبر و درست هست یا نه
        private bool IsPasswordValid(string hashedPassword, string enteredPassword)
        {
            var passwordHasher = new PasswordHasher();
            return passwordHasher.VerifyPassword(hashedPassword, enteredPassword);
        }
        //ایجاد نیجه خطا
        private ResultDto<ResultUserloginDto> CreateErrorResult(string errorMessage)
        {
            return new ResultDto<ResultUserloginDto>
            {
                Data = new ResultUserloginDto(),
                IsSuccess = false,
                Message = errorMessage
            };
        }
    }

    public class ResultUserloginDto
    {
        public long UserId { get; set; }
        public string Roles { get; set; }
        public string Name { get; set; }
    }
}
