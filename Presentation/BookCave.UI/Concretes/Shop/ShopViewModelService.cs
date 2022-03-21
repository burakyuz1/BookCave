using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Enums;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using BookCave.UI.Abstracts.Shop;
using BookCave.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookCave.UI.Concretes.Shop
{
    public class ShopViewModelService : IShopViewModelService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IRepository<Author> _authorRepository;


        public ShopViewModelService(
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

        public async Task<ShopViewModel> GetShopViewModelAsync(
            List<AuthorViewModel> authors,
            List<PublisherViewModel> publishers,
            int? categoryId,
            decimal min,
            decimal? max,
            OrderType orderType,
            string keyword,
            SearchType searchType,
            byte pageNumber)
        {
            var authorIds = authors.Where(x => x.IsSelected).Select(x => x.Id).ToList();
            var publisherIds = publishers.Where(x => x.IsSelected).Select(x => x.Id).ToList();

            int filteredTotalBookCount = await _bookRepository.CountAsync(new ShopBookFilterSpecification(authorIds, publisherIds, categoryId, min, max, orderType, keyword, searchType));

            int totalPageCount = (int)Math.Ceiling((double)filteredTotalBookCount / Constants.ITEMS_PER_PAGE);

            List<Author> authorsDb = await _authorRepository.GetAllAsync(new AuthorSpecification());
            List<Publisher> publishersDb = await _publisherRepository.GetAllAsync(new PublisherSpecification());
            List<Category> categories = await _categoryRepository.GetAllAsync(new CategorySpecification());
            List<Book> filteredPageBooks = await _bookRepository.GetAllAsync(new ShopBookFilterSpecification(authorIds, publisherIds, categoryId, min, max, orderType, (pageNumber - 1) * Constants.ITEMS_PER_PAGE, Constants.ITEMS_PER_PAGE,keyword, searchType));


            var publishersFilterById = publishersDb.Select(x => new PublisherViewModel()
            {
                Id = x.Id,
                PublisherName = x.Name,
                IsSelected = false
            }).ToList();
            SetTrueSelectedItem(publishersFilterById, publisherIds);

            var authorsFilterById = authorsDb.Select(x => new AuthorViewModel() //KOMPLE YAZARLAR
            {
                Id = x.Id,
                AuthorName = x.FullName,
                IsSelected = false
            }).ToList();
            SetTrueSelectedItem(authorsFilterById, authorIds);

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
                Keyword = keyword,
                PaginationInfo = new PaginationInfoViewModel()
                {
                    CurrentPage = pageNumber,
                    TotalItems = filteredTotalBookCount,
                    ItemsOnPage = (byte)filteredPageBooks.Count,
                    TotalPages = totalPageCount,
                    HasNext = pageNumber < totalPageCount,
                    HasPrevious = pageNumber > 1
                },
                Books = filteredPageBooks.Select(x => new BookViewModel()
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

    
        private void SetTrueSelectedItem<T>(ICollection<T> filteredList, List<int> ids)
        {
            foreach (dynamic item in filteredList)
                if (ids.Contains(item.Id))
                    item.IsSelected = true;
        }
    }
}
