using E_commerce.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Users.Queries.GetRole
{
    public interface IGetRoleService
    {
        ResultDto<List<RoleDto>> Execute();

    }
}
