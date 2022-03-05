using BookCave.Application.Abstracts.Shop;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCave.UI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IBookService _bookService;

        public ShopController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> Index()
        {
            var model =await _bookService.GetBookViewModelAsync();
            return View(model);
        }
    }
}
