using E_commerce.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Domain.Entities.Products
{
    public class Categories:BaseEntity
    {
        public string Name { get; set; }
        public virtual  Categories ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }
        public virtual ICollection<Categories> SubCategories { get; set; }
    }
}
