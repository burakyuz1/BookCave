using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.ViewModels
{
    public class BookViewModel
    {
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImagePath { get; set; }
        public string PublisherName { get; set; }
    }
}
