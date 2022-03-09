using BookCave.UI.ViewModels;
using System.Threading.Tasks;

namespace BookCave.UI.Abstracts.Home
{
    public interface IHomeService
    {
        Task<HomeBookViewModel> GetHomeBookViewModelAsync();
    }
}
