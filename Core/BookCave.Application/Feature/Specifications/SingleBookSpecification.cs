using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class SingleBookSpecification : Specification<Book>
    {
        public SingleBookSpecification(string isbn)
        {
            Query.Where(x => x.ISBN == isbn && x.Status && x.Stock > 0).Include(x => x.Author).Include(x => x.Publisher).Include(x => x.Comments);
        }
    }
}
