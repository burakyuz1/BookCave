using Ardalis.Specification;
using BookCave.Application.Enums;
using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class ShopBookFilterSpecification : Specification<Book>
    {
        public ShopBookFilterSpecification(List<int> authorIds, List<int> publisherIds, int? categoryId, int? min, int? max, OrderType orderType, string keyword, SearchType searchType)
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
            if (keyword != null)
            {
                switch (searchType)
                {
                    case SearchType.BY_BOOK_NAME:
                        Query.Where(x => x.Name.Contains(keyword));
                        break;
                    case SearchType.BY_PUBLISHER_NAME:
                        Query.Where(a => a.Publisher.Name.Contains(keyword));
                        break;
                    case SearchType.BY_AUTHOR_NAME:
                        Query.Where(a => a.Author.FullName.Contains(keyword));
                        break;
                }
            }
        }

        public ShopBookFilterSpecification(List<int> authorIds, List<int> publisherIds, int? categoryId, int? min, int? max, OrderType orderType, int skip, int take, string keyword, SearchType searchType) : this(authorIds, publisherIds, categoryId, min, max, orderType, keyword, searchType)
        {
            Query.Skip(skip).Take(take);
        }
    }
}
