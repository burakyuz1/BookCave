﻿using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.UI.Abstracts.Shop;
using BookCave.UI.ViewModels;
using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Application;

namespace BookCave.UI.Concretes.Shop
{
    public class ShopService : IShopService //ShopViewModelService olacak
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

        public async Task<ShopViewModel> GetShopViewModelAsync(List<AuthorViewModel> authors, List<PublisherViewModel> publishers, int? categoryId, int? min, int? max, OrderType orderType)
        {
            var authorIds = authors.Where(x=>x.IsSelected ).Select(x => x.AuthorId).ToList(); 
            var publisherIds = publishers.Where(x => x.IsSelected).Select(x => x.PublisherId).ToList();

            List<Author> authorsDb = await _authorRepository.GetAllAsync(new AuthorSpecification());
            List<Publisher> publishersDb = await _publisherRepository.GetAllAsync(new PublisherSpecification());
            List<Category> categories = await _categoryRepository.GetAllAsync(new CategorySpecification());
            List<Book> books = await _bookRepository.GetAllAsync(new ShopBookFilterSpecification(authorIds, publisherIds, categoryId, min, max, orderType));

            #region Refactor
            var publishersFilterById = publishersDb.Select(x => new PublisherViewModel()
            {
                PublisherId = x.Id,
                PublisherName = x.Name,
                IsSelected = false
            }).ToList();

            foreach (var item in publishersFilterById)
                if (publisherIds.Contains(item.PublisherId))
                    item.IsSelected = true;

            var authorsFilterById = authorsDb.Select(x => new AuthorViewModel() //KOMPLE YAZARLAR
            {
                AuthorId = x.Id,
                AuthorName = x.FullName,
                IsSelected = false
            }).ToList();

            foreach (var item in authorsFilterById)
                if (authorIds.Contains(item.AuthorId))
                    item.IsSelected = true; 
            #endregion

            return new()
            {
                CategoryId = categoryId,
                OrderType = orderType,
                CategoryName = categoryId.HasValue ? categories.FirstOrDefault(x => x.Id == categoryId.Value).Name : string.Empty,
                MaxPrice = max,
                MinPrice = min,
                Authors = authorsFilterById,
                Publishers = publishersFilterById,
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
