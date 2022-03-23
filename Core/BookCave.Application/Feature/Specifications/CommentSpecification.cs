using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class CommentSpecification : Specification<Comment>
    {
        public CommentSpecification(int skip, int take, string isbn)
        {
            Query.Where(x => x.ISBN == isbn && x.IsActive).Skip(skip).Take(take).OrderByDescending(x => x.CreatedDate);
        }
        public CommentSpecification(string userId)
        {
            Query.Where(x => x.UserId == userId && x.IsActive).Include(x => x.Book);
        }
    }
}
