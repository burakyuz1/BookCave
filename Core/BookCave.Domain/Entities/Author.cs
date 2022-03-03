using BookCave.Domain.Abstracts;
using BookCave.Domain.Entities.Common;
using System.Collections.Generic;

namespace BookCave.Domain.Entities
{
    public class Author : BaseEntity, IEntity
    {
        public string FullName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
