using Microsoft.AspNetCore.Mvc;

namespace BookCave.UI.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
