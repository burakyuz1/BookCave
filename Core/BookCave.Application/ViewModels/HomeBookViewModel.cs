using System.Collections.Generic;

namespace BookCave.Application.ViewModels
{
    public class HomeBookViewModel
    {
        public List<BookViewModel> TrendingBooks { get; set; }
        public List<BookViewModel> LastBooks { get; set; }
    }
}
