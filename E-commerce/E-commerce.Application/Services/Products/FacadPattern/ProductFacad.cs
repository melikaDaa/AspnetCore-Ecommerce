using E_commerce.Application.Interface;
using E_commerce.Application.Interface.FacadPattern;
using E_commerce.Application.Services.Products.Commands.AddNewCategory;
using E_commerce.Application.Services.Products.Commands.EditCategory;
using E_commerce.Application.Services.Products.Queries.GetAllCategories;
using E_commerce.Application.Services.Products.Queries.GetCategories;
using E_commerce.Application.Services.Products.Queries.GetProductDetailForAdmin;
using E_commerce.Application.Services.Products.Queries.GetProductDetailForSite;
using E_commerce.Application.Services.Products.Queries.GetProductForAdmin;
using E_commerce.Application.Services.Products.Queries.GetProductForSite;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;

        public ProductFacad(IDatabaseContext context,
             IHostingEnvironment environment
            )
        {
            _context = context;
            _environment = environment; 
        }

        private AddNewCategoryService _addNewCategory;
        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }


        private IGetCategoriesService _getCategoriesService;
        public IGetCategoriesService GetCategoriesService
        {
            get
            {
                return _getCategoriesService = _getCategoriesService ?? new GetCategoriesService(_context);
            }
        }
        private AddNewProductService _addNewProductService;
        public AddNewProductService AddNewProductService
        {
            get
            {
                return _addNewProductService = _addNewProductService ?? new AddNewProductService(_context, _environment);
            }
        }

        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }

        private IGetProductForAdminService _getProductForAdminService;
        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _getProductForAdminService = _getProductForAdminService ?? new GetProductForAdminService(_context);
            }
        }


        private IGetProductDetailForAdminService _getProductDetailForAdminService;
        public IGetProductDetailForAdminService GetProductDetailForAdminService
        {
            get
            {
                return _getProductDetailForAdminService = _getProductDetailForAdminService ?? new GetProductDetailForAdminService(_context);
            }
        }
        private IGetProductForSiteService _getProductForSiteService;
        public IGetProductForSiteService GetProductForSiteService
        {
            get
            {
                return _getProductForSiteService = _getProductForSiteService ?? new GetProductForSiteService(_context);
            }
        }

        private IGetProductDetailForSite _GetProductDetailForSite;
        public IGetProductDetailForSite GetProductDetailForSite
        {
            get
            {
                return _GetProductDetailForSite = _GetProductDetailForSite ?? new GetProductDetailForSite(_context);
            }
        }
        private IEditCategory _EditCategory;
        public IEditCategory EditCategory
        {
            get
            {
                return _EditCategory = _EditCategory ?? new EditCategory(_context);
            }
        }
    }
}
