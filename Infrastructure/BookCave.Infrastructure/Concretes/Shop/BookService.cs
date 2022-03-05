using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Abstracts.Shop;
using BookCave.Application.Feature.Specifications;
using BookCave.Application.ViewModels;
using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Infrastructure.Concretes.Shop
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }
        public async Task<List<BookViewModel>> GetBookViewModelAsync()
        {
            ShopBookFilterSpecification shopBookFilterSpec = new();
            List<Book> books = await _repository.GetAllAsync(shopBookFilterSpec);

            return books.Select(x => new BookViewModel()
            {
                AuthorName = x.Author.FullName,
                BookName = x.Name,
                ImagePath = x.ImageUri,
                ISBN = x.ISBN,
                PublisherName = x.Publisher.Name,
                UnitPrice = x.UnitPrice
            }).ToList();
        }
    }
}
