using BookCave.Domain.Entities.Common;
using System.Collections.Generic;

namespace BookCave.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
