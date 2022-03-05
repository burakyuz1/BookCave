using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Abstracts.Shop;
using BookCave.Application.Feature.Specifications;
using BookCave.Application.ViewModels;
using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.Infrastructure.Concretes.Shop
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<CategoryViewModel> GetCategoryViewModelAsync()
        {
            ShopCategoryFilterSpecification shopCategorySpec = new();

            List<Category> categories = await _repository.GetAllAsync(shopCategorySpec);

            return new() { Categories = categories };
        }
    }
}
