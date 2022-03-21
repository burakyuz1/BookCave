using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.ViewModels
{
    public class SingleBookViewModel
    {
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public string Description { get; set; }
        public int NumberOfPage { get; set; }
        public decimal UnitPrice { get; set; }
        public int PublishYear { get; set; }
        public string ImageUri { get; set; }
        public CommentDto CommentModel { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int CommentCount { get; set; }
    }
    public class CommentDto
    {
        public string CommentTitle { get; set; }
        public string CommentDescription { get; set; }
        public string CommentOwnerName { get; set; }
        public string CommentOwnerLastName { get; set; }
    }
}
