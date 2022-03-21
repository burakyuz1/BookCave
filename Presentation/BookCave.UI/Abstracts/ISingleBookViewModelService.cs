using BookCave.UI.ViewModels;
using System.Threading.Tasks;

namespace BookCave.UI.Abstracts
{
    public interface ISingleBookViewModelService
    {
        Task<SingleBookViewModel> GetSingleBookViewModelAsync(string isbn,int commentPage);
    }
}
