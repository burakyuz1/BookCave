using Ardalis.Specification;
using BookCave.Domain.Entities;
using System.Linq;

namespace BookCave.Application.Feature.Specifications
{
    public class BookSpecification : Specification<Book>
    {
        public BookSpecification()
        {

        }
        public BookSpecification(string isbn)
        {
            Query.Where(x => x.ISBN == isbn).Include(x => x.Author);
        }
        public BookSpecification(string isbn, bool empty)
        {
            Query.Where(x => x.ISBN == isbn).Include(x => x.Author).Include(a => a.Category).Include(a => a.Publisher);
        }
    }
}
