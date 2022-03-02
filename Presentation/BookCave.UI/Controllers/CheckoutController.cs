using Microsoft.AspNetCore.Mvc;

namespace BookCave.UI.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
