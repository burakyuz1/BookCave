using BookCave.UI.Abstracts.Cart;
using BookCave.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCave.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartViewModelService _cartService;

        public CartController(ICartViewModelService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddBookToCart(string isbn, int quantity = 1)
        {
           var cartVm =  await _cartService.AddToCartAsync(isbn, quantity);

            return Json(new NavCartViewModel() { TotalQuantityCartLines = cartVm.TotalCartLines,TotalPriceCartLine = cartVm.TotalPrice});
        }
    }
}
