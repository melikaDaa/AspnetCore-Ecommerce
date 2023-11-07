using System.Collections.Generic;


namespace E_commerce.Application.Services.Users.Queries.GetUser
{
    public class ReslutGetUserDto
    {
        public List<GetUserDto> Users { get; set; }
        public int Rows { get; set; }
    }
}
