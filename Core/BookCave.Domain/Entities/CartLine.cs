using BookCave.Domain.Abstracts;
using BookCave.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Domain.Entities
{
    public class CartLine : BaseEntity, IEntity
    {
        public Book Book { get; set; }
        public string ISBN { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}
