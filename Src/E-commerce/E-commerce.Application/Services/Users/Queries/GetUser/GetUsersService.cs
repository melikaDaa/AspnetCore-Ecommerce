using E_commerce.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Common;
namespace E_commerce.Application.Services.Users.Queries.GetUser
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDatabaseContext _context;
        public GetUsersService(IDatabaseContext context)
        {
            _context = context;
        }

        public  ReslutGetUserDto Execute(RequestGetUserDto request)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }
            int rowcount = 0;
            var usersList = users.ToPaged(request.Page, 20, out rowcount).Select(p => new GetUserDto
            {
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id,
                IsActive = p.IsActive
            }) .ToList();

            return new ReslutGetUserDto
            {
                Rows = rowcount,
                Users = usersList,
            };

        }
    }
}
