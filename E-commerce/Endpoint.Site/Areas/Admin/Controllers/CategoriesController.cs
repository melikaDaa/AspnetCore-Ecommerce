using E_commerce.Application.Interface.FacadPattern;
using E_commerce.Application.Services.Products.Commands.EditCategory;
using E_commerce.Application.Services.Products.FacadPattern;
using E_commerce.Application.Services.Users.Commands.EditUser;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IProductFacad _productfacad;

        public CategoriesController(IProductFacad productfacad)
        {
            _productfacad = productfacad;
        }
        public IActionResult Index(long? parentId)
        {
            return View(_productfacad.GetCategoriesService.Execute(parentId).Data);
        }

        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(long? ParentId, string Name)
        {
            var result = _productfacad.AddNewCategoryService.Execute(ParentId, Name);
            return Json(result);
        }
        [HttpPost]
        public IActionResult Edit(long Id, string name)
        {
            return Json(_productfacad.EditCategory.Execute(new RequestEditcategoryDto
            {
                name = name,
                Id = Id,
            }));
        }
    }
}
