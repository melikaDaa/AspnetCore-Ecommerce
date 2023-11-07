using E_commerce.Application.Services.Users.Commands.EditUser;
using E_commerce.Application.Services.Users.Commands.RegisterUser;
using E_commerce.Application.Services.Users.Commands.RemoveUser;
using E_commerce.Application.Services.Users.Commands.UserSatusChange;
using E_commerce.Application.Services.Users.Queries.GetRole;
using E_commerce.Application.Services.Users.Queries.GetUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _GetUsersService;
        private readonly IGetRoleService _GetroleServie;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserSatusChangeService _userSatusChangeService;
        private readonly IEditUserService _editUserService;

        public UsersController(IGetUsersService getUsersService, 
            IGetRoleService _getroleServie,
            IRegisterUserService registerUserService,
                 IRemoveUserService removeUserService,
                 IUserSatusChangeService userSatusChangeService,
                 IEditUserService editUserService
                 )
        {
            _GetUsersService = getUsersService;
            _GetroleServie = _getroleServie;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _userSatusChangeService = userSatusChangeService;
            _editUserService = editUserService; 


        }

        public IActionResult Index(string serchkey, int page = 1)
        {
            return View(_GetUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = serchkey,
            }));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_GetroleServie.Execute().Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                roles = new List<RolesInRegisterUserDto>()
                   {
                        new RolesInRegisterUserDto
                        {
                             Id= RoleId
                        }
                   },
                Password = Password,
                RePasword = RePassword,
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }
        [HttpPost]
        public IActionResult UserSatusChange(long UserId)
        {
            return Json(_userSatusChangeService.Execute(UserId));
        }
        [HttpPost]
        public IActionResult Edit(long UserId, string Fullname)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = Fullname,
                UserId = UserId,
            }));
        }
    }
}
