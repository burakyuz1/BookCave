using BookCave.Domain.Entities;
using System.Collections.Generic;

namespace BookCave.UI.ViewModels
{
    public class ShopViewModel
    {
        public int? MaxPrice { get; set; }
        public int? MinPrice { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Category> Categories { get; set; }
        public List<BookViewModel> Books { get; set; }
        public List<AuthorViewModel> Authors { get; set; }
        public List<PublisherViewModel> Publishers { get; set; }
    }
}
