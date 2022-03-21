using BookCave.UI.Abstracts;
using Microsoft.AspNetCore.Mvc;
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
