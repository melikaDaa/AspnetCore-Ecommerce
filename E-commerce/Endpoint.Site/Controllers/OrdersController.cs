using E_commerce.Application.Services.Orders.Queries.GetUserOrders;
using Endpoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IGetUserOrdersService _getUserOrdersService;
        public OrdersController(IGetUserOrdersService getUserOrdersService)
        {
            _getUserOrdersService = getUserOrdersService;
        }
        public IActionResult Index()
        {
            long userId = ClaimUtility.GetUserId(User).Value;
            return View(_getUserOrdersService.Execute(userId).Data);
        }
    }
}
