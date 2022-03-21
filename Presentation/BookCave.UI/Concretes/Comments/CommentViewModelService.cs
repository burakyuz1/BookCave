using BookCave.Application.Abstracts;
using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using BookCave.UI.Abstracts.Comment;
using BookCave.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
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
        private readonly IRepository<Order> _commentRepository;

        public CommentViewModelService(ICommentService commentService, IHttpContextAccessor httpContext, IRepository<Order> commentRepository)
        {
            _commentService = commentService;
            _httpContext = httpContext;
            _commentRepository = commentRepository;
        }
        public async Task<string> AddCommentToBook(SingleBookViewModel singleBook)
        {
            var comment = new Comment()
            {
                IsActive = true,
                Title = singleBook.CommentTitle,
                ISBN = singleBook.ISBN,
                Content = singleBook.CommentDescription,
                UserId = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            await _commentService.AddCommentAsync(comment);
            return singleBook.ISBN;
        }

        public Task<List<CommentViewModel>> GetCommentViewModelAsync(string userId)
        {
            //userıd'ye göre user comments getir
            //
        }
    }
}
