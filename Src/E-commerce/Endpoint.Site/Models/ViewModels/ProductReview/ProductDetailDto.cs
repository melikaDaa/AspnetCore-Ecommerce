using E_commerce.Application.Services.Products.Queries.GetProductDetailForSite;
using E_commerce.Application.Services.Reviews;
using System.Collections.Generic;

namespace Endpoint.Site.Models.ViewModels.ProductReview
{
    public class ProductDetailDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public int ViewCount { get; set; }
        public List<ReviewDto> Reviews { get; set; }
        public ProductDetailForSiteDto Product { get; internal set; }
    }

}
