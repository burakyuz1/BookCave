using BookCave.UI.ViewModels;
using System.Threading.Tasks;

namespace BookCave.UI.Abstracts
{
    public interface IHomeViewModelService
    {
        Task<HomeBookViewModel> GetHomeBookViewModelAsync();
    }
}
