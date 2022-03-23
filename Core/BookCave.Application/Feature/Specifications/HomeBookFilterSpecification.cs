using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class HomeBookFilterSpecification : Specification<Book>
    {
        public HomeBookFilterSpecification(string type)
        {
            if (type == "trendingBook")
            {
                Query.Where(x=>x.Status && x.Stock > 0).Take(10).Include(x => x.Author).Include(x => x.Publisher).OrderByDescending(x => x.SalesQuantity);
            }
            if (type == "lastBook")
            {
                Query.Where(x => x.Status && x.Stock > 0).Take(7).Include(x => x.Author).Include(x => x.Publisher).OrderByDescending(x => x.CreatedDate);
            }
        }


    }
}
