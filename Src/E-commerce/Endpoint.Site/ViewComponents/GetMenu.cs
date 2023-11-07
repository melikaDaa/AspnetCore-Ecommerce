﻿using E_commerce.Application.Services.Common.Queries.GetMenuItem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.ViewComponents
{
    public class GetMenu:ViewComponent
    {
        private readonly IGetMenuItemService _getMenuItemService;
        public GetMenu(IGetMenuItemService getMenuItemService)
        {
            _getMenuItemService = getMenuItemService;
        }


        public IViewComponentResult Invoke()
        {
            var menuItem = _getMenuItemService.Execute();
            return View(viewName: "GetMenu", menuItem.Data);
        }

    }
}
