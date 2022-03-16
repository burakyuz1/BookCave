using BookCave.Application.Abstracts;
using BookCave.Domain.Entities;
using BookCave.UI.Abstracts.Comment;
using BookCave.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Concretes.Comments
{
    public class CommentViewModelService : ICommentViewModelService
    {
        private readonly ICommentService _commentService;

        public CommentViewModelService(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<string> AddCommentToBook(SingleBookViewModel singleBook)
        {
            var comment = new Comment()
            {
                IsActive = true,
                Title = singleBook.CommentTitle,
                ISBN = singleBook.ISBN,
                Content = singleBook.CommentDescription
            };
            await _commentService.AddCommentAsync(comment);
            return singleBook.ISBN;
        }
    }
}
