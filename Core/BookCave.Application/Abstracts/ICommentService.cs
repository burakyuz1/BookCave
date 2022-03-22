using BookCave.Domain.Entities;
using System.Threading.Tasks;

namespace BookCave.Application.Abstracts
{
    public interface ICommentService
    {
        Task<Comment> AddCommentAsync(Comment comment);
    }
}
