using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using BookCave.UI.Abstracts.Book;
using BookCave.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Concretes.Books
{
    public class SingleBookViewModelService : ISingleBookViewModelService
    {
        private readonly IRepository<Book> _bookRepository;

        public SingleBookViewModelService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<SingleBookViewModel> GetSingleBookViewModelAsync(string isbn)
        {
            var singleBook = await _bookRepository.FirstOrDefaultAsync(new SingleBookSpecification(isbn));
            return BookToSingleBookVm(singleBook);
        }

        private SingleBookViewModel BookToSingleBookVm(Book book)
        {
            return new ()
            {
                ISBN = book.ISBN,
                BookName = book.Name,
                ImageUri = book.ImageUri,
                NumberOfPage = book.NumberOfPages,
                UnitPrice = book.UnitPrice,
                PublishYear = book.PublishYear,
                Description = book.Details,
                AuthorName = book.Author.FullName,
                Comments = book.Comments,
                PublisherName = book.Publisher.Name
            };
        }
    }
}
