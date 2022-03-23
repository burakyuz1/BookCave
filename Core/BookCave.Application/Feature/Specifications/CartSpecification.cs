using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class CartSpecification : Specification<Cart>
    {
        public CartSpecification(string userId)
        {
            Query.Where(x => x.UserId == userId).Include(x => x.CartLines).ThenInclude(x => x.Book).ThenInclude(x => x.Author);
        }
        public CartSpecification(int cartId)
        {
            Query.Where(x => x.Id == cartId).Include(a => a.CartLines).ThenInclude(x => x.Book);
        }
    }
}
