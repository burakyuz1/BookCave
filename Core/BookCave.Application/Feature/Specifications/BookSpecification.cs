using Ardalis.Specification;
using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Feature.Specifications
{
   public class BookSpecification :Specification<Book>
    {
        public BookSpecification(string isbn)
        {
            Query.Where(x => x.ISBN == isbn).Include(x=>x.Author);
        }
    }
}
