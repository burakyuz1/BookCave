using BookCave.Application.ViewModels;
using System.Threading.Tasks;

namespace BookCave.Application.Abstracts.Shop
{
    public interface IAuthorService
    {
        Task<AuthorViewModel> GetAuthorViewModelAsync();
    }
}
