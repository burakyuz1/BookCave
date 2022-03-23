using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using BookCave.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class AuthorController : Controller
    {
        private readonly IRepository<Author> _authorRepo;

        public AuthorController(IRepository<Author> authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public async Task<IActionResult> Index()
        {
            var author = (await _authorRepo.GetAllAsync()).OrderBy(x => x.FullName).ToList();
            return View(author);
        }
        public async Task<IActionResult> AddAuthor()
        {
            var model = new AddAuthorViewModel()
            {

            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(AddAuthorViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Author author = new()
                {
                    Id = vm.Id,
                    FullName = vm.FullName
                };
                await _authorRepo.AddAsync(author);
                TempData["success"] = "Author added successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> AuthorUpdate()
        {
            var author = await _authorRepo.FirstOrDefaultAsync(new AuthorSpecification());
            var model = new UpdateAuthorViewModel()
            {
                FullName = author.FullName
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AuthorUpdate(UpdateAuthorViewModel vm)
        {
            var author = await _authorRepo.FirstOrDefaultAsync(new AuthorSpecification());
            if (ModelState.IsValid)
            {
                author.FullName = vm.FullName;
            }
            await _authorRepo.UpdateAsync(author);
            return RedirectToAction("Index");
        }
    }
}
