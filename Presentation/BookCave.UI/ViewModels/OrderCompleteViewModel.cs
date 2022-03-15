using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.ViewModels
{
    public class OrderCompleteViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalWithTaxes { get; set; }
        public decimal TotalWithoutTaxes { get; set; }
        public ICollection<OrderDetail> OrderDetails{ get; set; }
        public Contact Contact { get; set; }
    }
}
