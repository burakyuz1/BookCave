using BookCave.Application.ViewModels;
using System.Threading.Tasks;

namespace BookCave.Application.Abstracts.Home
{
    public interface IHomeService
    {
        Task<HomeBookViewModel> GetHomeBookViewModelAsync();
    }
}
