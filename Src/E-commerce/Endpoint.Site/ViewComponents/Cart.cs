using E_commerce.Application.Services.Carts;
using Endpoint.Site.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.ViewComponents
{
    public class Cart : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly CookiesManeger _cookiesManeger;
        public Cart(ICartService cartService)
        {
            _cartService = cartService;
            _cookiesManeger = new CookiesManeger();
        }

        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            return View(viewName: "Cart", _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), userId).Data);
        }
    }
    }
