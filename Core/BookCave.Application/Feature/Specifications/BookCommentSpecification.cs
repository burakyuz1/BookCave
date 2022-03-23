using Ardalis.Specification;
using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Feature.Specifications
{
    public class BookCommentSpecification : Specification<Book>
    {
        public BookCommentSpecification(string isbn)
        {
            Query.Where(x => x.ISBN == isbn && x.Status && x.Stock > 0);
        }
    }
}
