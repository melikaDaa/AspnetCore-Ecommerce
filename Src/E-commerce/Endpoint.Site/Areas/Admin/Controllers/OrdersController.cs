using E_commerce.Application.Services.Orders.Queries.GetOrdersForAdmin;
using E_commerce.Domain.Entities.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly IGetOrdersForAdminService _getOrdersForAdminService;
        public OrdersController(IGetOrdersForAdminService getOrdersForAdminService)
        {
            _getOrdersForAdminService = getOrdersForAdminService;
        }
        public IActionResult Index(OrderState orderState)
        {
            return View(_getOrdersForAdminService.Execute(orderState).Data);
        }
    }
}
