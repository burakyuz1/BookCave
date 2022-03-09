using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class ShopBookFilterSpecification : Specification<Book>
    {
        public ShopBookFilterSpecification(List<int> authorIds, List<int> publisherIds, int? categoryId, int? min, int? max)
        {
            if (categoryId.HasValue)
            {
                Query.Where(x => x.CategoryId == categoryId.Value);
            }
            if (authorIds.Count > 0)
            {
                Query.Where(x => authorIds.Contains(x.AuthorId.Value));
            }
            if (min.HasValue && max.HasValue)
            {
                Query.Where(x => x.UnitPrice >= min && x.UnitPrice <= max);
            }
            if (publisherIds.Count > 0)
            {
                Query.Where(x => publisherIds.Contains(x.PublisherId.Value));
            }
            Query.OrderByDescending(x => x.SalesQuantity).Include(x => x.Publisher).Include(x => x.Author);
        }
    }
}
