using BookCave.Domain.Abstracts;
using BookCave.Domain.Entities.Common;
using System.Collections.Generic;

namespace BookCave.Domain.Entities
{
    public class Category: BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
