using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using BookCave.UI.Abstracts;
using BookCave.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Concretes
{
    public class SingleBookViewModelService : ISingleBookViewModelService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Comment> _commentRepository;

        public SingleBookViewModelService(IRepository<Book> bookRepository, IRepository<Comment> commentRepository)
        {
            _bookRepository = bookRepository;
            _commentRepository = commentRepository;
        }

        public async Task<SingleBookViewModel> GetSingleBookViewModelAsync(string isbn, int commentPage)
        {
            var singleBook = await _bookRepository.FirstOrDefaultAsync(new SingleBookSpecification(isbn));
            int skip = (commentPage - 1) * Constants.COMMENTS_PER_PAGE;
            int take = Constants.COMMENTS_PER_PAGE;
            var pagedComment = await _commentRepository.GetAllAsync(new CommentSpecification(skip, take, isbn));

            int totalCommentCount = singleBook.Comments.Where(x => x.IsActive).Count();
            int totalPageCount = (int)Math.Ceiling((decimal)totalCommentCount / Constants.COMMENTS_PER_PAGE);

            PaginationInfoViewModel paginationInfo = new()
            {
                CurrentPage = commentPage,
                TotalPages = totalPageCount,
                ItemsOnPage = pagedComment.Count,
                TotalItems = totalCommentCount,
                HasNext = commentPage < totalPageCount,
                HasPrevious = commentPage > 1,
                Start = (commentPage - 1) * Constants.COMMENTS_PER_PAGE + 1,
                End = ((commentPage - 1) * Constants.COMMENTS_PER_PAGE) + pagedComment.Count
            };

            return BookToSingleBookVm(singleBook, pagedComment, paginationInfo);
        }

        private SingleBookViewModel BookToSingleBookVm(Book book, ICollection<Comment> comments, PaginationInfoViewModel paginationInfo)
        {
            return new()
            {
                ISBN = book.ISBN,
                BookName = book.Name,
                ImageUri = book.ImageUri,
                NumberOfPage = book.NumberOfPages,
                UnitPrice = book.UnitPrice,
                PublishYear = book.PublishYear,
                Description = book.Details,
                AuthorName = book.Author.FullName,
                Comments = comments,
                PublisherName = book.Publisher.Name,
                PaginationInfo = paginationInfo,
                CommentCount = paginationInfo.TotalItems
            };
        }
    }
}
