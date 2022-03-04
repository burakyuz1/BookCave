using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class HomeBookFilterSpecification : Specification<Book>
    {
        public HomeBookFilterSpecification()
        {
            Query.Take(10).Include(x => x.Author).Include(x => x.Publisher);
        }
    }
}
