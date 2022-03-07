using BookCave.Domain.Entities;
using System.Collections.Generic;

namespace BookCave.Application.ViewModels
{
    public class AuthorViewModel
    {
        public List<AuthorSelect> AuthorSelects { get; set; }
    }
    public class AuthorSelect
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public bool IsSelected { get; set; }
    }
}
