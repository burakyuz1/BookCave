using Ardalis.Specification;
using System.Linq;
using BookCave.Domain.Entities;

namespace BookCave.Application.Feature.Specifications
{
    public class ShopPublisherFilterSpecification : Specification<Publisher>
    {
        public ShopPublisherFilterSpecification()
        {
            Query.OrderBy(x => x.Name);
        }
    }
}
