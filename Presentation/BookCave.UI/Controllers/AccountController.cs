using Microsoft.AspNetCore.Mvc;

namespace BookCave.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
          public IActionResult Comments()
        {
            return View();
        }
          public IActionResult Addresses()
        {
            return View();
        }
          public IActionResult Details()
        {
            return View();
        }
    }
}
