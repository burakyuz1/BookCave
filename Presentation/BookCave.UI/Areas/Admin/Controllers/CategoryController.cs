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
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var category = (await _categoryRepository.GetAllAsync()).OrderByDescending(x => x.Name).ToList();
            return View(category);
        }

        public IActionResult AddCategory()
        {
            return View(new AddCategoryViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel vm)
        {
            if(ModelState.IsValid)
            {
                Category category = new()
                {
                    Id = vm.CategoryId,
                    Name = vm.CategoryName
                };

                await _categoryRepository.AddAsync(category);
                TempData["success"] = "Category added successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> UpdateCategory()
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(new CategorySpecification());
            var model = new UpdateCategoryViewModel()
            {
                CategoryName = category.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryViewModel vm)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(new CategorySpecification());
            if (ModelState.IsValid)
            {
                category.Name = vm.CategoryName;
                await _categoryRepository.UpdateAsync(category);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
