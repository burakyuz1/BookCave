using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class ShopBookFilterSpecification : Specification<Book>
    {
        public ShopBookFilterSpecification(List<int> authorIds, List<int> publisherIds, int? categoryId, int? min, int? max, OrderType orderType)
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
            switch (orderType)
            {
                case OrderType.DECREASING:
                    Query.OrderByDescending(x => x.UnitPrice).Include(x => x.Publisher).Include(x => x.Author);
                    break;
                case OrderType.INCREASING:
                    Query.OrderBy(x => x.UnitPrice).Include(x => x.Publisher).Include(x => x.Author);
                    break;
                default:
                    Query.OrderByDescending(x => x.SalesQuantity).Include(x => x.Publisher).Include(x => x.Author);
                    break;
            }
        }

        public ShopBookFilterSpecification(List<int> authorIds, List<int> publisherIds, int? categoryId, int? min, int? max, OrderType orderType, int skip, int take) : this(authorIds, publisherIds, categoryId, min, max, orderType)
        {
            Query.Skip(skip).Take(take);
        }

    }
}
