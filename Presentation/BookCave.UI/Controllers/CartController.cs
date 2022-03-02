using Microsoft.AspNetCore.Mvc;

namespace BookCave.UI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
