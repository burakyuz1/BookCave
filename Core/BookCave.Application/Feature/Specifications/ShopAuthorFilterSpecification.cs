using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class ShopAuthorFilterSpecification : Specification<Author>
    {
        public ShopAuthorFilterSpecification()
        {
            Query.OrderBy(x => x.FullName);
        }
    }
}
