using BookCave.Application.Abstracts.Shop;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.ViewComponents
{
    public class ShopCategoryFilterViewComponent : ViewComponent
    {
        private readonly ICategoryService _category;

        public ShopCategoryFilterViewComponent(ICategoryService category)
        {
            _category = category;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _category.GetCategoryViewModelAsync();

            return View(model);
        }
    }
}
