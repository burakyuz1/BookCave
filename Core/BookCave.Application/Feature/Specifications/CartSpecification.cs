using Ardalis.Specification;
using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Feature.Specifications
{
   public  class CartSpecification : Specification<Cart>
    {
        public CartSpecification(string userId)
        {
            Query.Where(x => x.CustomerId == userId).Include(x=>x.CartLines).ThenInclude(x=>x.Book);
        }
        public CartSpecification(int cartId)
        {
            Query.Where(x => x.Id == cartId);
        }
    }
}
