using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class ShopBookFilterSpecification : Specification<Book>
    {
        public ShopBookFilterSpecification(int? categoryId, List<int> authorIds, List<int> publisherIds)
        {
            if (categoryId.HasValue)
            {
                Query.Where(x => x.CategoryId == categoryId.Value);
            }
            if (authorIds.Count > 0)
            {
                Query.Where(x => authorIds.Contains(x.AuthorId.Value));
            }
            if (publisherIds.Count > 0)
            {
                Query.Where(x => publisherIds.Contains(x.PublisherId.Value));
            }

            Query.OrderByDescending(x => x.SalesQuantity).Include(x => x.Publisher).Include(x => x.Author);
        }
    }
}
