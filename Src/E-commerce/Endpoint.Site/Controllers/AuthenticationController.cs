﻿using E_commerce.Application.Services.Users.Commands.RegisterUser;
using E_commerce.Application.Services.Users.Commands.UserLogin;
using E_commerce.Common.Dto;
using Endpoint.Site.Models.ViewModels.AuthenticationViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System;
using Microsoft.EntityFrameworkCore;
using E_commerce.Application.Services.Reviews;
using E_commerce.Application.Interface;
using System.Linq;

namespace Endpoint.Site.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly IUserLoginService _userLoginService;
        private readonly IReviewService _review;
        private readonly IDatabaseContext _context;
        public AuthenticationController(IRegisterUserService registerUserService, IUserLoginService userLoginService
            , IReviewService review, IDatabaseContext context)
        {
            _registerUserService = registerUserService;
            _userLoginService = userLoginService;
            _review = review;
            _context = context;
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.RePassword))
            {
                return Json(new ResultDto { IsSuccess = false, Message = "لطفا تمامی موارد رو ارسال نمایید" });
            }

            if (User.Identity.IsAuthenticated == true)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "شما به حساب کاربری خود وارد شده اید! و در حال حاضر نمیتوانید ثبت نام مجدد نمایید" });
            }
            if (request.Password != request.RePassword)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "رمز عبور و تکرار آن برابر نیست" });
            }
            if (request.Password.Length < 8)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "رمز عبور باید حداقل 8 کاراکتر باشد" });
            }

            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";

            var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return Json(new ResultDto { IsSuccess = true, Message = "ایمیل خودرا به درستی وارد نمایید" });
            }


            var signeupResult = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                RePasword = request.RePassword,
                roles = new List<RolesInRegisterUserDto>()
                {
                     new RolesInRegisterUserDto { Id = 3},
                }
            });

            if (signeupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,signeupResult.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Name, request.FullName),
                new Claim(ClaimTypes.Role, "Customer"),
            };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(signeupResult);
        }

        public IActionResult Signin(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Signin(string Email, string Password, string url = "/")
        {
            var signupResult = _userLoginService.Execute(Email, Password);
            if (signupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,signupResult.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, signupResult.Data.Name),
                new Claim(ClaimTypes.Role, signupResult.Data.Roles ),
            };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(signupResult);
        }

        public IActionResult UserPanel()
        {
            var currentUser = _context.Users
                .SingleOrDefault(u => u.FullName == User.Identity.Name);

            if (currentUser != null)
            {
                var productReviews = _review.GetReviewsByUserId(currentUser.Id).Data;
                return View(productReviews);
            }

            return RedirectToAction("Login", "Account");
        }


        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
