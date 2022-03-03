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
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.ISBN });
            builder.Property(x => x.Quantity).IsRequired(); //TODO: Min:0 max:255
            builder.Property(x => x.UnitPrice).IsRequired().HasPrecision(18, 2); // TODO: min-max
        }
    }
}
