using System.Collections.Generic;

namespace BookCave.BookCave.UI.ViewModels
{
    public class AuthorViewModel
    {
        public List<AuthorSelect> AuthorSelects { get; set; }
        public List<int> Ids { get; set; }
    }
    public class AuthorSelect
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public bool IsSelected { get; set; }
    }
}
