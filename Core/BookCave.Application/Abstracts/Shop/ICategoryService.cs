using BookCave.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCave.Application.Abstracts.Shop
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategoryViewModelAsync();
    }
}
