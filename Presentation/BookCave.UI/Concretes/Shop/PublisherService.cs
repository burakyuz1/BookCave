using BookCave.Application.Abstracts.Repository;
using BookCave.BookCave.UI.Abstracts.Shop;
using BookCave.Application.Feature.Specifications;
using BookCave.BookCave.UI.ViewModels;
using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.BookCave.UI.Concretes.Shop
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepository<Publisher> _repository;

        public PublisherService(IRepository<Publisher> repository )
        {
            _repository = repository;
        }

        public async Task<PublisherViewModel> GetPublisherViewModelAsync()
        {
            ShopPublisherFilterSpecification shopPublisherFilterSpec = new();

            List<Publisher> publisher = await _repository.GetAllAsync(shopPublisherFilterSpec);

            return new()
            {
                PublisherSelects = publisher.Select(x => new PublisherSelect()
                {
                    PublisherId = x.Id,
                    PublisherName = x.Name
                }).ToList()
            };
        }
    }
}
