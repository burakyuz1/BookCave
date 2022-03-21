using Ardalis.Specification;
using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Feature.Specifications
{
    public class CommentSpecification:Specification<Comment>
    {
        public CommentSpecification(string userId)
        {
            Query.Where(a => a.UserId == userId);
        }
    }
}
