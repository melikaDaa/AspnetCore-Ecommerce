using E_commerce.Application.Services.Reviews;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Endpoint.Site.ViewComponents
{
    public class Review: ViewComponent
    {
        public IViewComponentResult Invoke(List<ReviewDto> reviews)
        {
            return View(viewName: "Review", reviews);
        }
    }
}
