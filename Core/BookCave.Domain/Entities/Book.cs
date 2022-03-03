using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Domain.Entities
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int PublishYear { get; set; }
        public ushort NumberOfPages { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUri { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
        public int? PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<CategoryDetail> CategoryDetails { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
