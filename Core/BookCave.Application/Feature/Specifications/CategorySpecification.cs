using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class CategorySpecification : Specification<Category>
    {
        public CategorySpecification()
        {
            Query.OrderBy(x => x.Name);
        }
    }
}
