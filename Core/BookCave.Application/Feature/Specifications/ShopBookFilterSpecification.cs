using Ardalis.Specification;
using BookCave.Application.Enums;
using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class ShopBookFilterSpecification : Specification<Book>
    {
        public ShopBookFilterSpecification(List<int> authorIds, List<int> publisherIds, int? categoryId, decimal min, decimal? max, OrderType orderType, string keyword, SearchType searchType)
        {
            var bookQuery = Query.Where(x => x.Status && x.Stock > 0);
            if (categoryId.HasValue)
            {
                bookQuery.Where(x => x.CategoryId == categoryId.Value);
            }
            if (authorIds.Count > 0)
            {
                bookQuery.Where(x => authorIds.Contains(x.AuthorId.Value));
            }
            if (min > 0 && max.HasValue)
            {
                bookQuery.Where(x => x.UnitPrice >= min && x.UnitPrice <= max);
            }
            if (publisherIds.Count > 0)
            {
                bookQuery.Where(x => publisherIds.Contains(x.PublisherId.Value));
            }
            switch (orderType)
            {
                case OrderType.DECREASING:
                    bookQuery.OrderByDescending(x => x.UnitPrice).Include(x => x.Publisher).Include(x => x.Author);
                    break;
                case OrderType.INCREASING:
                    bookQuery.OrderBy(x => x.UnitPrice).Include(x => x.Publisher).Include(x => x.Author);
                    break;
                default:
                    bookQuery.OrderByDescending(x => x.SalesQuantity).Include(x => x.Publisher).Include(x => x.Author);
                    break;
            }
            if (keyword != null)
            {
                #region C# 3
                //switch (searchType)
                //{
                //    case SearchType.BY_BOOK_NAME:
                //        bookQuery.Where(x => x.Name.Contains(keyword));
                //        break;
                //    case SearchType.BY_PUBLISHER_NAME:
                //        bookQuery.Where(a => a.Publisher.Name.Contains(keyword));
                //        break;
                //    case SearchType.BY_AUTHOR_NAME:
                //        bookQuery.Where(a => a.Author.FullName.Contains(keyword));
                //        break;
                //} 
                #endregion
                _ = searchType switch
                {
                    SearchType.BY_BOOK_NAME => bookQuery.Where(x => x.Name.Contains(keyword)),
                    SearchType.BY_PUBLISHER_NAME => bookQuery.Where(a => a.Publisher.Name.Contains(keyword)),
                    SearchType.BY_AUTHOR_NAME => bookQuery.Where(a => a.Author.FullName.Contains(keyword))
                };
            }
        }

        public ShopBookFilterSpecification(List<int> authorIds, List<int> publisherIds, int? categoryId, decimal min, decimal? max, OrderType orderType, int skip, int take, string keyword, SearchType searchType) : this(authorIds, publisherIds, categoryId, min, max, orderType, keyword, searchType)
        {
            Query.Where(x=>x.Status && x.Stock > 0).Skip(skip).Take(take);
        }
    }
}
