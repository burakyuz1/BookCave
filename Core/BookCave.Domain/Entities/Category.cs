using BookCave.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Domain.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CategoryDetail> CategoryDetails { get; set; }
    }
}
