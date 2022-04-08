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
    public class PublisherController : Controller
    {
        private readonly IRepository<Publisher> _publisherRepo;

        public PublisherController(IRepository<Publisher> publisherRepo)
        {
            _publisherRepo = publisherRepo;
        }
        public async Task<IActionResult> Index()
        {
            var publisher = (await _publisherRepo.GetAllAsync()).OrderBy(x => x.Name).ToList();
            return View(publisher);
        }
        public IActionResult AddPublisher()
        {
            return View(new AddPublisherViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AddPublisher(AddPublisherViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Publisher publisher = new()
                {
                    Id = vm.Id,
                    Name = vm.Name
                };
                await _publisherRepo.AddAsync(publisher);
                TempData["success"] = "Publisher added successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> PublisherUpdate()
        {
            var publisher = await _publisherRepo.FirstOrDefaultAsync(new PublisherSpecification());
            var model = new UpdatePublisherViewModel()
            {
                Name = publisher.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> PublisherUpdate(UpdatePublisherViewModel vm)
        {
            var publisher = await _publisherRepo.FirstOrDefaultAsync(new PublisherSpecification());
            if (ModelState.IsValid)
            {
                publisher.Name = vm.Name;
            }
            await _publisherRepo.UpdateAsync(publisher);
            return RedirectToAction("Index");
        }

    }
}
