using BookCave.Domain.Abstracts;
using BookCave.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Domain.Entities
{
    public class Contact : BaseEntity, IEntity
    {
        public string AddressTitle { get; set; }
        public string AddressDescription { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        // public int? userId gte set
        // public user user gte set
    }
}
