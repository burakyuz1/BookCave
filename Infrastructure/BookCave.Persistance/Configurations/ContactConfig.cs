using BookCave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Persistance.Configurations
{
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.AddressTitle).IsRequired().HasMaxLength(20);
            builder.Property(x => x.AddressDescription).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(40);
            builder.Property(x => x.City).IsRequired().HasMaxLength(40);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(15);
            //TODO: user bağlantısı
        }
    }
}
