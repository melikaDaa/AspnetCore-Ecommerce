using E_commerce.Application.Interface;
using E_commerce.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Users.Queries.GetRole
{
    public class GetRoleService : IGetRoleService
    {
        private readonly IDatabaseContext _context;

        public GetRoleService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<RoleDto>> Execute()
        {
            var roles = _context.Roles.ToList().Select(p => new RoleDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<RoleDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = "",
            };
        }
    }
}
