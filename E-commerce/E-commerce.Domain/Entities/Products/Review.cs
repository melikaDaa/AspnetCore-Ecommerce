using E_commerce.Domain.Entities.Commons;
using E_commerce.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Domain.Entities.Products
{
    public class Review : BaseEntity
    {
        [Required(ErrorMessage = "لطفا متن نظر پر کنید")]
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public bool Approved { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }

       
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

}
