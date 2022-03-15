using BookCave.UI.Abstracts.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.ViewComponents
{
    public class CheckoutCartViewComponent : ViewComponent
    {
        private readonly ICartViewModelService _viewModelService;

        public CheckoutCartViewComponent(ICartViewModelService viewModelService)
        {
            _viewModelService = viewModelService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _viewModelService.GetCartViewModelAsync();
            return View(model);
        }
    }
}
