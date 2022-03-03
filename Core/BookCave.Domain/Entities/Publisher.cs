using BookCave.Domain.Entities.Common;
using System.Collections.Generic;

namespace BookCave.Domain.Entities
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
