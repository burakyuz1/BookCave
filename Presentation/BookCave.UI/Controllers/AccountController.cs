using Microsoft.AspNetCore.Mvc;

namespace BookCave.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
