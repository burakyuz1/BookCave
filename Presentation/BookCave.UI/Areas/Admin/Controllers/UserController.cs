using BookCave.Persistance.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCave.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public  IActionResult Index()
        {
            var users =  _userManager.Users;    
            return View(users);
        }

        public async Task<IActionResult> ChangeStatus(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.EmailConfirmed = !user.EmailConfirmed;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

   
    }
}
