using BookCave.UI.Abstracts.Shop;
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
        public async Task<IActionResult> Index(List<int> authorIds, List<int> publisherIds, int? categoryId, int? min, int? max)
        {
            var model = await _shopService.GetShopViewModelAsync(authorIds, publisherIds, categoryId, min, max);
            return View(model);
        }
    }
}
