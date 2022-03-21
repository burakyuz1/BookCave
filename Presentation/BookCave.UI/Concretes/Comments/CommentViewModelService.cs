using BookCave.Application.Abstracts;
using BookCave.Domain.Entities;
using BookCave.UI.Abstracts.Comment;
using BookCave.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookCave.UI.Concretes.Comments
{
    public class CommentViewModelService : ICommentViewModelService
    {
        private readonly ICommentService _commentService;
        private readonly IHttpContextAccessor _httpContext;

        public CommentViewModelService(
            ICommentService commentService,
            IHttpContextAccessor httpContext)
        {
            _commentService = commentService;
            _httpContext = httpContext;

        }
        public async Task<string> AddCommentToBook(SingleBookViewModel singleBook)
        {
            string userId = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var comment = new Comment()
            {
                IsActive = true,
                Title = singleBook.CommentModel.CommentTitle,
                ISBN = singleBook.ISBN,
                Content = singleBook.CommentModel.CommentDescription,
                UserId = userId,
            };
            await _commentService.AddCommentAsync(comment);
            return singleBook.ISBN;
        }
    }
}
