using BookCave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCave.Persistance.Configurations
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.ISBN });
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.Book).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ISBN);
            builder.Property(x => x.Quantity).IsRequired(); 
            builder.Property(x => x.UnitPrice).IsRequired().HasPrecision(18, 2); 
        }
    }
}
