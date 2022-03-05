using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Abstracts.Shop;
using BookCave.Application.Feature.Specifications;
using BookCave.Application.ViewModels;
using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCave.Infrastructure.Concretes.Shop
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _repository;

        public AuthorService(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<AuthorViewModel> GetAuthorViewModelAsync()
        {
            ShopAuthorFilterSpecification shopAuthorFilterSpec = new();

            List<Author> authors = await _repository.GetAllAsync(shopAuthorFilterSpec);

            return new() { Authors = authors };
        }
    }
}
