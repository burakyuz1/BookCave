using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCave.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CommentController : Controller
    {
        private readonly IRepository<Comment> _commentRepository;

        public CommentController(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var comments = await _commentRepository.GetAllAsync(new CommentSpecification());
            return View(comments);  
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            var comment = await _commentRepository.FirstOrDefaultAsync(new CommentSpecification(id));
            comment.IsActive = !comment.IsActive;
            await _commentRepository.UpdateAsync(comment);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CommentDetail(int id)
        {
            var comment = await _commentRepository.FirstOrDefaultAsync(new CommentSpecification(id)); 
            return View(comment);
        }
    }
}
