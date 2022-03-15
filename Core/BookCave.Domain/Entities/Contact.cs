using BookCave.Domain.Abstracts;
using BookCave.Domain.Entities.Common;

namespace BookCave.Domain.Entities
{
    public class Contact
    {
        public Contact()
        {

        }
        public Contact(string name, string lastName, string addressDescription, string city, string country, string phoneNumber)
        {
            Name = name;
            LastName = lastName;
            AddressDescription = addressDescription;
            City = city;
            Country = country;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string AddressDescription { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}
