using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.UI.Abstracts.Shop;
using BookCave.UI.ViewModels;
using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Concretes.Shop
{
    public class ShopService : IShopService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IRepository<Author> _authorRepository;


        public ShopService(
            IRepository<Book> repository,
            IRepository<Category> categoryRepository,
            IRepository<Author> authorRepository,
            IRepository<Publisher> publisherRepository)
        {
            _bookRepository = repository;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<ShopViewModel> GetShopViewModelAsync(List<int> authorIds, List<int> publisherIds, int? categoryId, int? min, int? max)
        {
            List<Author> authors = await _authorRepository.GetAllAsync(new AuthorSpecification());
            List<Publisher> publishers = await _publisherRepository.GetAllAsync(new PublisherSpecification());
            List<Category> categories = await _categoryRepository.GetAllAsync(new CategorySpecification());
            List<Book> books = await _bookRepository.GetAllAsync(new ShopBookFilterSpecification(authorIds, publisherIds, categoryId, min, max));
            
            return new()
            {
                CategoryId = categoryId,
                CategoryName = categoryId.HasValue ? categories.FirstOrDefault(x => x.Id == categoryId.Value).Name : string.Empty,
                MaxPrice = max,
                MinPrice = min,
                Authors = authors.Select(x => new AuthorViewModel() { AuthorId = x.Id, AuthorName = x.FullName }).ToList(),
                Publishers = publishers.Select(x => new PublisherViewModel() { PublisherId = x.Id, PublisherName = x.Name }).ToList(),
                Categories = categories,
                Books = books.Select(x => new BookViewModel()
                {
                    ISBN = x.ISBN,
                    BookName = x.Name,
                    UnitPrice = x.UnitPrice,
                    ImagePath = x.ImageUri,
                    PublisherName = x.Publisher.Name,
                    AuthorName = x.Author.FullName
                }).ToList()
            };
        }
    }
}
