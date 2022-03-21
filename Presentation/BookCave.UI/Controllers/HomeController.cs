using BookCave.UI.Abstracts;
using BookCave.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCave.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeViewModelService _homeService;
        public HomeController(IHomeViewModelService homeService)
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
