using Microsoft.AspNetCore.Mvc;

namespace BookCave.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
