using BookCave.Domain.Abstracts;
using BookCave.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Domain.Entities
{
    public class Cart : BaseEntity, IEntity
    {
        public string CustomerId { get; set; }
        public List<CartLine> CartLines { get; set; } = new List<CartLine>();
    }
}
