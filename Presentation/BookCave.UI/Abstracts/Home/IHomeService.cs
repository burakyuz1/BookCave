using BookCave.BookCave.UI.ViewModels;
using System.Threading.Tasks;

namespace BookCave.BookCave.UI.Abstracts.Home
{
    public interface IHomeService
    {
        Task<HomeBookViewModel> GetHomeBookViewModelAsync();
    }
}
