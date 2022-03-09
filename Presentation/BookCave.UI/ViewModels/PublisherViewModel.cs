using System.Collections.Generic;

namespace BookCave.BookCave.UI.ViewModels
{
    public class PublisherViewModel
    {
        public List<PublisherSelect> PublisherSelects { get; set; }
    }
    public class PublisherSelect
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public bool IsSelected { get; set; }
    }
}
