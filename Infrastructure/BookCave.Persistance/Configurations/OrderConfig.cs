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
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.UserId).HasMaxLength(450).IsRequired();

            builder.OwnsOne(x => x.ContactDetails, navBuilder =>
            {
                navBuilder.WithOwner();
                navBuilder.Property(x => x.Name).HasMaxLength(20).IsRequired();
                navBuilder.Property(x => x.LastName).HasMaxLength(20).IsRequired();
                navBuilder.Property(x => x.PhoneNumber).HasMaxLength(15).IsRequired();
                navBuilder.Property(x => x.AddressDescription).HasMaxLength(100).IsRequired();
                navBuilder.Property(x => x.City).HasMaxLength(25).IsRequired();
                navBuilder.Property(x => x.Country).HasMaxLength(30).IsRequired();
            });

            builder.Navigation(x => x.ContactDetails).IsRequired();
        }
    }
}
