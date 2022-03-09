using BookCave.BookCave.UI.Abstracts.Shop;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCave.UI.ViewComponents
{
    public class ShopAuthorFilterViewComponent : ViewComponent
    {
        private readonly IAuthorService _authorService;

        public ShopAuthorFilterViewComponent(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _authorService.GetAuthorViewModelAsync();
            return View(model);
        }

    }
}
