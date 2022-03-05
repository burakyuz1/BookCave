using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class ShopCategoryFilterSpecification : Specification<Category>
    {
        public ShopCategoryFilterSpecification()
        {
            Query.OrderBy(x => x.Name);
        }
    }
}
