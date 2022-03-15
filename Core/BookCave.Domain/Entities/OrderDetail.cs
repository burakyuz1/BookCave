using BookCave.Domain.Abstracts;
using BookCave.Domain.Entities.Common;

namespace BookCave.Domain.Entities
{
    public class OrderDetail : IEntity
    {
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public string ISBN { get; set; }
        public Book Book { get; set; }
        public string BookName { get; set; }
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string PictureUri { get; set; }
    }
}
