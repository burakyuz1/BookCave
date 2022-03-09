using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class AuthorSpecification : Specification<Author>
    {
        public AuthorSpecification()
        {
            Query.OrderBy(x => x.FullName);
        }
    }
}
