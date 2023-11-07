using E_commerce.Application.Services.Common.Queries.GetCategory;
using E_commerce.Application.Services.Common.Queries.GetMenuItem;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.ViewComponents
{
    public class Search:ViewComponent
    {
        private readonly IGetCategoryService _getMenuItemService;
        public Search(IGetCategoryService getMenuItemService)
        {
            _getMenuItemService = getMenuItemService;
        }


        public IViewComponentResult Invoke()
        {
            return View(viewName: "Search", _getMenuItemService.Execute().Data);
        }
    }
}
