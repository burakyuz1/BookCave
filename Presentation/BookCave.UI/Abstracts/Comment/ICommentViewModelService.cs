using BookCave.UI.ViewModels;
using System.Threading.Tasks;

namespace BookCave.UI.Abstracts.Comment
{
    public interface ICommentViewModelService
    {
        Task<string> AddCommentToBook(SingleBookViewModel singleBook);
    }
}
