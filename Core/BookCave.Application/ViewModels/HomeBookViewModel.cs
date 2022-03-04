using System.Collections.Generic;

namespace BookCave.Application.ViewModels
{
    public class HomeBookViewModel
    {
        public List<BookViewModel> HomeBooks { get; set; }
    }
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
