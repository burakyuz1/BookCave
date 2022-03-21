using BookCave.UI.Abstracts;
using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.UI.ViewModels;
using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCave.UI.Concretes
{
    public class HomeViewModelService : IHomeViewModelService 
    {
        private readonly IRepository<Book> _repository;

        public HomeViewModelService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<HomeBookViewModel> GetHomeBookViewModelAsync()
        {
            HomeBookFilterSpecification trendingBookFilter = new("trendingBook");
            List<Book> trendingBooks = await _repository.GetAllAsync(trendingBookFilter);

            HomeBookFilterSpecification lastBookFilter = new("lastBook");
            List<Book> lastBooks = await _repository.GetAllAsync(lastBookFilter);

            List<BookViewModel> trendingBookVM = MapBookModel(trendingBooks);

            List<BookViewModel> lastBookVM = MapBookModel(lastBooks);

            return new() { TrendingBooks = trendingBookVM, LastBooks = lastBookVM };
        }

        private List<BookViewModel> MapBookModel(List<Book> dbBooks)
        {
            List<BookViewModel> bookViemModel = new();

            foreach (var book in dbBooks)
            {
                bookViemModel.Add(new()
                {
                    ISBN = book.ISBN,
                    BookName = book.Name,
                    ImagePath = book.ImageUri,
                    UnitPrice = book.UnitPrice,
                    PublisherName = book.Publisher.Name,
                    AuthorName = book.Author.FullName
                });
            }
            return bookViemModel;
        }
    }
}
