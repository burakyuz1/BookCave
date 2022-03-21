using BookCave.Application.Abstracts;
using BookCave.Domain.Entities;
using BookCave.UI.Abstracts.Book;
using BookCave.UI.Abstracts.Comment;
using BookCave.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCave.UI.Controllers
{
    public class BookController : Controller
    {
        private readonly ISingleBookViewModelService _singleBookViewModelService;
        private readonly ICommentViewModelService _commentViewModelService;

        public BookController(ISingleBookViewModelService singleBookViewModelService, ICommentViewModelService commentViewModelService)
        {
            _singleBookViewModelService = singleBookViewModelService;
            _commentViewModelService = commentViewModelService;
        }
        public async Task<IActionResult> Index(string isbn, int commentPage = 1)
        {
            var model = await _singleBookViewModelService.GetSingleBookViewModelAsync(isbn, commentPage);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddComment(SingleBookViewModel model)
        {
            string isbn = await _commentViewModelService.AddCommentToBook(model);
            return RedirectToAction("Index", "Book", new { isbn = isbn });
        }
    }
}
