using BookCave.Application.Abstracts;
using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Concretes
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Book> _bookRepository;

        public CommentService(IRepository<Comment> commentRepository, IRepository<Book> bookRepository)
        {
            _commentRepository = commentRepository;
            _bookRepository = bookRepository;
        }
        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            if (comment == null)
                throw new ArgumentException("Comment can not pass empty!");

            var book = await _bookRepository.FirstOrDefaultAsync(new BookCommentSpecification(comment.ISBN));
            if (book == null)
                throw new ArgumentException("Book couldnt found!");

            comment.IsActive = true;
            await _commentRepository.AddAsync(comment);
            return comment;
        }
    }
}
