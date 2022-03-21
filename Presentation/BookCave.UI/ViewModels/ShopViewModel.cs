using BookCave.Application.Enums;
using BookCave.Domain.Entities;
using System.Collections.Generic;

namespace BookCave.UI.ViewModels
{
    public class ShopViewModel
    {
        public decimal MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Keyword { get; set; }
        public OrderType OrderType { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
        public List<Category> Categories { get; set; }
        public List<BookViewModel> Books { get; set; }
        public List<AuthorViewModel> Authors { get; set; }
        public List<PublisherViewModel> Publishers { get; set; }
    }
}
