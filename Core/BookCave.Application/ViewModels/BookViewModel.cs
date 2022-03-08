using BookCave.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.ViewModels
{
    public class BookCategoryViewModel
    {
        public int? Max { get; set; }
        public int? Min { get; set; }
        public int? CategoryId { get; set; }
        //public List<Category> Categories { get; set; }
        public string CategoryName { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<BookViewModel> Books { get; set; }
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
