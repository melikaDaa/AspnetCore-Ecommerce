using E_commerce.Domain.Entities.Commons;
using System.Collections.Generic;

namespace E_commerce.Domain.Entities.Users
{
    public class Role:BaseEntity
    {
        public string  Name { get; set; }
        public ICollection<UserInRole > UserInRoles { get; set; }
    }
}
