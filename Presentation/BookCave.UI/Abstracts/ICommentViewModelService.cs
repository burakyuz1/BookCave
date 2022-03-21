using BookCave.UI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCave.UI.Abstracts
{
    public interface ICommentViewModelService
    {
        Task<string> AddCommentToBook(SingleBookViewModel singleBook);
        Task<List<CommentViewModel>> GetCommentViewModelAsync(string userId);
    }
}
