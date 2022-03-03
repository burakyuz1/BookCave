using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Domain.Entities
{
    public class OrderDetail
    {
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public string ISBN { get; set; }
        public Book Book { get; set; }
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
