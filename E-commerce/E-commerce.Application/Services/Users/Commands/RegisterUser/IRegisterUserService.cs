using E_commerce.Application.Interface;
using E_commerce.Application.Services.Users.Queries.GetRole;
using E_commerce.Common;
using E_commerce.Common.Dto;
using E_commerce.Common.Roles;
using E_commerce.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }

    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDatabaseContext _context;

        public RegisterUserService(IDatabaseContext context)
        {
            _context = context;
        }
        //ثبت نام کاربر
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)

        {
            try
            {
                var validationResult = ValidateInput(request);
                if (!validationResult.IsSuccess)
                {
                    return validationResult;
                }

                var hashedPassword = HashPassword(request.Password);

                var user = CreateUser(request, hashedPassword);

                AddUserToContext(user);

                return new ResultDto<ResultRegisterUserDto>
                {
                    Data = new ResultRegisterUserDto
                    {
                        UserId = user.Id
                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد"
                };
            }
            catch (Exception)
            {
                return new ResultDto<ResultRegisterUserDto>
                {
                    Data = new ResultRegisterUserDto(),
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد!"
                };
            }
        }
        //بررسی ورودی ها 
        private ResultDto<ResultRegisterUserDto> ValidateInput(RequestRegisterUserDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return CreateErrorResult("پست الکترونیک را وارد نمایید");
            }

            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                return CreateErrorResult("نام را وارد نمایید");
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return CreateErrorResult("رمز عبور را وارد نمایید");
            }

            if (request.Password != request.RePasword)
            {
                return CreateErrorResult("رمز عبور و تکرار آن برابر نیست");
            }

            var emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
            var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return CreateErrorResult("ایمیل خودرا به درستی وارد نمایید");
            }

            return new ResultDto<ResultRegisterUserDto> { IsSuccess = true };
        }

        //هش کردن پسورد
        private string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher();
            return passwordHasher.HashPassword(password);
        }
        // ایجاد یک شیء کاربر با مشخصات درخواستی
        private User CreateUser(RequestRegisterUserDto request, string hashedPassword)
        {
            var user = new User
            {
                Email = request.Email,
                FullName = request.FullName,
                Password = hashedPassword,
                IsActive = true
            };

         //   List<UserInRole> userInRoles = CreateRolesList(request.Roles, user);
          //  user.UserInRoles = userInRoles;
            return user;
        }
        // ایجاد نقش‌ها برای کاربر و افزودن به لیست نقش‌ها
        private List<UserInRole> CreateRolesList(List<RoleDto> roles, User user)
        {
            var userInRoles = new List<UserInRole>();

            foreach (var role in roles)
            {
                var dbRole = _context.Roles.Find(role.Id);
                userInRoles.Add(new UserInRole
                {
                    Role = dbRole,
                    RoleId = dbRole.Id,
                    User = user,
                    UserId = user.Id
                });
            }

            return userInRoles;
        }
        // افزودن کاربر به مخزن داده و ذخیره تغییرات
        private void AddUserToContext(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        // ایجاد نتیجه خطا با پیام مناسب
        private ResultDto<ResultRegisterUserDto> CreateErrorResult(string errorMessage)
        {
            return new ResultDto<ResultRegisterUserDto>
            {
                Data = new ResultRegisterUserDto(),
                IsSuccess = false,
                Message = errorMessage
            };
        }
    }

    public class RequestRegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePasword { get; set; }
        public List<RolesInRegisterUserDto> roles { get; set; }
    }

    public class RolesInRegisterUserDto
    {
        public long Id { get; set; }
    }

    public class ResultRegisterUserDto
    {
        public long UserId { get; set; }

    }



}
