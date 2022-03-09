using Ardalis.Specification;
using System.Linq;
using BookCave.Domain.Entities;

namespace BookCave.Application.Feature.Specifications
{
    public class PublisherSpecification : Specification<Publisher>
    {
        public PublisherSpecification()
        {
            Query.OrderBy(x => x.Name);
        }
    }
}
