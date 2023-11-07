using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Users.Queries.GetUser
{
    public interface IGetUsersService
    {
        ReslutGetUserDto Execute(RequestGetUserDto request);

    }
}
