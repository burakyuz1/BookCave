using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class SingleBookSpecification : Specification<Book>
    {
        public SingleBookSpecification(string isbn)
        {
            Query.Where(x => x.ISBN == isbn).Include(x => x.Author).Include(x => x.Publisher).Include(x => x.Comments);
        }
    }
}
