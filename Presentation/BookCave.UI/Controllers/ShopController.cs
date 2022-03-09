﻿using BookCave.Application;
using BookCave.UI.Abstracts.Shop;
using BookCave.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        public async Task<IActionResult> Index(List<AuthorViewModel> authors , List<PublisherViewModel> publishers, int? categoryId, int? minPrice, int? maxPrice, OrderType orderType)
        {
            var model = await _shopService.GetShopViewModelAsync(authors, publishers, categoryId, minPrice, maxPrice, orderType);
            return View(model);
        }
    }
}
