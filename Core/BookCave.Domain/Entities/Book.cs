using BookCave.Domain.Abstracts;
using BookCave.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace BookCave.Domain.Entities
{
    public class Book : IEntity
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int PublishYear { get; set; }
        public ushort NumberOfPages { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUri { get; set; }
        public int Stock { get; set; }
        public int SalesQuantity { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
        public int? PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CartLine> CartLines { get; set; }
    }
}
