using Microsoft.AspNetCore.Mvc;

namespace BookCave.UI.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
