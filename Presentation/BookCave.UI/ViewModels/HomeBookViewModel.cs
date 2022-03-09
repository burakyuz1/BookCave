using System.Collections.Generic;

namespace BookCave.BookCave.UI.ViewModels
{
    public class HomeBookViewModel
    {
        public List<BookViewModel> TrendingBooks { get; set; }
        public List<BookViewModel> LastBooks { get; set; }
    }
}
