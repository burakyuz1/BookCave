using BookCave.Application.Abstracts.Home;
using BookCave.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCave.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            HomeBookViewModel model = await _homeService.GetHomeBookViewModelAsync();
            return View(model);
        }
    }
}
