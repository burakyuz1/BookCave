using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class ShopBookFilterSpecification : Specification<Book>
    {
        public ShopBookFilterSpecification()
        {
            Query.OrderByDescending(x => x.SalesQuantity).Include(x => x.Publisher).Include(x => x.Author);
        }
    }
}
