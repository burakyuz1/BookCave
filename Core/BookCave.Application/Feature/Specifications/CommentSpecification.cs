using Ardalis.Specification;
using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Feature.Specifications
{
    public class CommentSpecification : Specification<Comment>
    {
        public CommentSpecification(int skip, int take, string isbn)
        {
            Query.Where(x => x.ISBN == isbn).Skip(skip).Take(take).OrderByDescending(x => x.CreatedDate);
        }
        public CommentSpecification(string userId)
        {
            Query.Where(x => x.UserId == userId).Include(x => x.Book);
        }
        public CommentSpecification ()
        {
            Query.Include(x => x.Book).OrderByDescending(x=>x.CreatedDate);
        }
        public CommentSpecification(int id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}
