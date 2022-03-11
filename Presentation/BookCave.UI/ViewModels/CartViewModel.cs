using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.ViewModels
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public string CustomerId { get; set; }
        public List<CartLineViewModel> CartLines { get; set; }
        public decimal TotalPrice => CartLines.Sum(a => a.TotalPrice);
        public int TotalCartLines => CartLines.Sum(a => a.Quantity);
    }
}
