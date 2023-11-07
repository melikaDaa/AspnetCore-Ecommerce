using E_commerce.Application.Interface.FacadPattern;
using E_commerce.Application.Services.Products.Queries.GetProductForSite;
using E_commerce.Application.Services.Reviews;
using Endpoint.Site.Models.ViewModels.ProductReview;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Endpoint.Site.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductFacad _productFacad;
        private readonly IReviewService _reviewService;

        public ProductsController(IProductFacad productFacad, IReviewService reviewService)
        {
            _productFacad = productFacad;
            _reviewService = reviewService;
        }
        public IActionResult Index(Ordering ordering,string Searchkey, long? CatId=null, int page = 1, int pageSize = 20)
        {
            return View(_productFacad.GetProductForSiteService
                                      .Execute(ordering,Searchkey, page,pageSize, CatId).Data);
        }

        public IActionResult Detail(long Id)
        {
            var productDetail = _productFacad.GetProductDetailForSite.Execute(Id).Data;
            var productReviews = _reviewService.GetReviewsByProductId(Id).Data;

            var viewModel = new ProductDetailViewModel
            {
                Product = productDetail,
                Reviews = productReviews
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddReview(long productId, string comment)
        {
            var userId = Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var result = _reviewService.AddReview(userId, productId, comment);

            if (result.IsSuccess)
            {
                return Json(new { isSuccess = true, message = result.Message });
            }
            else
            {
                return Json(new { isSuccess = false, message = result.Message });
            }
        }

    }
}
