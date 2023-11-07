using E_commerce.Application.Services.Products.Commands.AddNewCategory;
using E_commerce.Application.Services.Products.Commands.EditCategory;
using E_commerce.Application.Services.Products.Queries.GetAllCategories;
using E_commerce.Application.Services.Products.Queries.GetCategories;
using E_commerce.Application.Services.Products.Queries.GetProductDetailForAdmin;
using E_commerce.Application.Services.Products.Queries.GetProductDetailForSite;
using E_commerce.Application.Services.Products.Queries.GetProductForAdmin;
using E_commerce.Application.Services.Products.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Interface.FacadPattern
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSite GetProductDetailForSite { get; }
        IEditCategory EditCategory { get; }

    }
}
