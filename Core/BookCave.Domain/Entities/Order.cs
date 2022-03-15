using BookCave.Domain.Abstracts;
using BookCave.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace BookCave.Domain.Entities
{
    public class Order : BaseEntity, IEntity
    {
        public string UserId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Contact ContactDetails { get; set; }
    }
}
