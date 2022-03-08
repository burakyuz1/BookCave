using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Abstracts.Shop;
using BookCave.Application.Feature.Specifications;
using BookCave.Application.ViewModels;
using BookCave.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Infrastructure.Concretes.Shop
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Category> _categoryRepository;

        public BookCategoryService(IRepository<Book> repository, IRepository<Category> categoryRepository)
        {
            _bookRepository = repository;
            _categoryRepository = categoryRepository;
        }
        public async Task<BookCategoryViewModel> GetBookCategoryViewModel(int? categoryId, AuthorViewModel author, int? min, int? max)
        {

            List<int> authorIds = new List<int>();

            if (author.AuthorSelects != null)
                foreach (var item in author.AuthorSelects)
                    if (item.IsSelected == true)
                        authorIds.Add(item.AuthorId);

            ShopBookFilterSpecification shopBookFilterSpec = new(categoryId, authorIds,min,max);
            ShopCategoryFilterSpecification shopCategoryFilter = new();


            List<Book> books = await _bookRepository.GetAllAsync(shopBookFilterSpec);
            List<Category> categories = await _categoryRepository.GetAllAsync(shopCategoryFilter);

            List<BookViewModel> bookViews = books.Select(x => new BookViewModel()
            {
                AuthorName = x.Author.FullName,
                BookName = x.Name,
                ImagePath = x.ImageUri,
                ISBN = x.ISBN,
                PublisherName = x.Publisher.Name,
                UnitPrice = x.UnitPrice
            }).ToList();

            return new()
            {
                Min = min,
                Max = max,
                CategoryId = categoryId,
                Books = bookViews,
                CategoryName = categoryId.HasValue ? categories.FirstOrDefault(x => x.Id == categoryId.Value).Name : string.Empty,
                Categories = categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
            };
        }
    }
}
