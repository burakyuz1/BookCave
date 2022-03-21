using BookCave.Application.Abstracts;
using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using BookCave.UI.Abstracts.Comment;
using BookCave.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookCave.UI.Concretes.Comments
{
    public class CommentViewModelService : ICommentViewModelService
    {
        private readonly ICommentService _commentService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IRepository<Comment> _commentRepository;

        public CommentViewModelService(
            ICommentService commentService,
            IHttpContextAccessor httpContext,
            IRepository<Comment> commentRepository)
        {
            _commentService = commentService;
            _httpContext = httpContext;
            _commentRepository = commentRepository;
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

        public async Task<List<CommentViewModel>> GetCommentViewModelAsync(string userId)
        {
            var comment = await _commentRepository.GetAllAsync(new CommentSpecification(userId));

            return comment.Select(a => new CommentViewModel()
            {
                CommentContent = a.Content.Length > 35 ? a.Content.Substring(0, 35) + "..." : a.Content,
                CommentDate = a.CreatedDate,
                CommentTitle = a.Title,
                BookName = a.Book.Name,
                PictureUri = a.Book.ImageUri,
                ISBN=a.ISBN,
            }).ToList();
        }
    }
}
