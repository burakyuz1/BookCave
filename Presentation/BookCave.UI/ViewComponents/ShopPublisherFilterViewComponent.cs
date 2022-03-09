using System.Threading.Tasks;
using BookCave.BookCave.UI.Abstracts.Shop;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.UI.ViewComponents
{
    public class ShopPublisherFilterViewComponent : ViewComponent
    {
        private readonly IPublisherService _publisherService;

        public ShopPublisherFilterViewComponent(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _publisherService.GetPublisherViewModelAsync();
            return View(model);
        }
    }
}
