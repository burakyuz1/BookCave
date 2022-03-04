using BookCave.Application.Abstracts.Home;
using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Application.ViewModels;
using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.Infrastructure.Concretes.Home
{
    public class HomeService : IHomeService
    {
        private readonly IRepository<Book> _repository;

        public HomeService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<HomeBookViewModel> GetHomeBookViewModelAsync()
        {
            HomeBookFilterSpecification homeBookFilterSpecification = new();
            List<Book> books = await _repository.GetAllAsync(homeBookFilterSpecification);

            List<BookViewModel> homeBooks = new();

            foreach (var book in books)
            {
                homeBooks.Add(new()
                {
                    ISBN = book.ISBN,
                    BookName = book.Name,
                    ImagePath = book.ImageUri,
                    UnitPrice = book.UnitPrice,
                    PublisherName = book.Publisher.Name,
                    AuthorName = book.Author.FullName
                });
            }

            return new() { HomeBooks = homeBooks };
        }
    }
}
