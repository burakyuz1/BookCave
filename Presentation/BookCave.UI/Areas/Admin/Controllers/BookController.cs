using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using BookCave.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BookCave.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class BookController : Controller
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Publisher> _publisherRepo;
        private readonly IRepository<Author> _authorRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IWebHostEnvironment _env;

        public BookController(IRepository<Book> bookRepository,
            IRepository<Publisher> publisherRepo,
            IRepository<Author> authorRepo,
            IRepository<Category> categoryRepo,
            IWebHostEnvironment env)
        {
            _bookRepository = bookRepository;
            _publisherRepo = publisherRepo;
            _authorRepo = authorRepo;
            _categoryRepo = categoryRepo;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var books = (await _bookRepository.GetAllAsync()).OrderByDescending(x => x.CreatedDate).ToList();
            return View(books);
        }
        public async Task<IActionResult> ChangeStatus(string isbn)
        {
            var book = await _bookRepository.FirstOrDefaultAsync(new BookSpecification(isbn));
            book.Status = !book.Status;
            await _bookRepository.UpdateAsync(book);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddBook()
        {
            var model = new AddBookViewModel()
            {
                Publishers = (await _publisherRepo.GetAllAsync()).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList(),
                Authors = (await _authorRepo.GetAllAsync()).Select(x => new SelectListItem() { Text = x.FullName, Value = x.Id.ToString() }).ToList(),
                Categories = (await _categoryRepo.GetAllAsync()).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList()
            };
            return View(model);
        }

        public async Task<IActionResult> BookDetail(string isbn)
        {
            var book = await _bookRepository.FirstOrDefaultAsync(new BookSpecification(isbn, true));
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Book book = new()
                {
                    AuthorId = vm.SelectedAuthorId,
                    PublisherId = vm.SelectedPublisherId,
                    CategoryId = vm.SelectedCategoryId,
                    Name = vm.BookName,
                    ISBN = vm.ISBN,
                    UnitPrice = vm.Price,
                    Stock = vm.Stock,
                    NumberOfPages = (ushort)vm.NumberOfPage,
                    PublishYear = vm.PublishYear,
                    Status = true,
                    ImageUri = UploadImage(vm.Picture),
                    Details = vm.Details
                };
                await _bookRepository.AddAsync(book);
                TempData["success"] = "Book added successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> UpdateBook(string isbn)
        {
            var book = await _bookRepository.FirstOrDefaultAsync(new BookSpecification(isbn));
            var model = new UpdateBookViewModel()
            {
                ISBN = book.ISBN,
                BookName = book.Name,
                Details = book.Details,
                NumberOfPage = book.NumberOfPages,
                Price = book.UnitPrice,
                PublishYear = book.PublishYear,
                Stock = book.Stock,
                PictureUri = book.ImageUri,
                Publishers = (await _publisherRepo.GetAllAsync()).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList(),
                Authors = (await _authorRepo.GetAllAsync()).Select(x => new SelectListItem() { Text = x.FullName, Value = x.Id.ToString() }).ToList(),
                Categories = (await _categoryRepo.GetAllAsync()).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList(),
                SelectedAuthorId = book.AuthorId.Value,
                SelectedCategoryId = book.CategoryId.Value,
                SelectedPublisherId = book.PublisherId.Value
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(UpdateBookViewModel vm)
        {
            var book = await _bookRepository.FirstOrDefaultAsync(new BookSpecification(vm.ISBN));
            if (ModelState.IsValid)
            {
                book.ISBN = vm.ISBN;
                book.Name = vm.BookName;
                book.Stock = vm.Stock;
                book.UnitPrice = vm.Price;
                book.PublishYear = vm.PublishYear;
                book.AuthorId = vm.SelectedAuthorId;
                book.PublisherId = vm.SelectedPublisherId;
                book.CategoryId = vm.SelectedCategoryId;
                book.Details = vm.Details;
                book.NumberOfPages = (ushort)vm.NumberOfPage;

                if (vm.Picture != null)
                {
                    DeleteImage(vm.PictureUri);
                    book.ImageUri = UploadImage(vm.Picture);
                }
                await _bookRepository.UpdateAsync(book);
                return RedirectToAction("Index");
            }

            return View();
        }

        private string UploadImage(IFormFile file)
        {
            string fileName = null;
            if (file != null)
            {
                fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string destinationPath = Path.Combine(_env.WebRootPath, "img", "books", fileName);
                using (var fs = new FileStream(destinationPath, FileMode.Create))
                {
                    file.CopyTo(fs);
                }
            }
            return fileName;
        }

        private void DeleteImage(string fileName)
        {
            if (fileName == null) return;
            string deletePath = Path.Combine(_env.WebRootPath, "img", "books", fileName);
            try
            {
                System.IO.File.Delete(deletePath);
            }
            catch (Exception)
            {
            }
        }
    }
}
