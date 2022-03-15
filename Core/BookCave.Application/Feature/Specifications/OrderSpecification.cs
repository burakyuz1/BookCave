using Ardalis.Specification;
using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Feature.Specifications
{
    public class OrderSpecification : Specification<Order>
    {
        public OrderSpecification(int orderId)
        {
            Query.Where(a => a.Id == orderId).Include(x => x.OrderDetails).ThenInclude(ezgi=> ezgi.Book).ThenInclude(ayse=>ayse.Author);
        }
    }
}
