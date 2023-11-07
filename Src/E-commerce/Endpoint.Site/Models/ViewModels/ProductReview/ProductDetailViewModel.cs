using E_commerce.Application.Services.Products.Queries.GetProductDetailForSite;
using E_commerce.Application.Services.Reviews;
using System.Collections.Generic;

namespace Endpoint.Site.Models.ViewModels.ProductReview
{
    public class ProductDetailViewModel
    {
        public ProductDetailForSiteDto Product { get; set; }

        public List<ReviewDto> Reviews { get; set; }
        public ReviewDto Review { get; set; }
    }
}
