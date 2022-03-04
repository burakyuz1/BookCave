using BookCave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCave.Persistance.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.ISBN);
            builder.Property(x => x.ISBN).HasMaxLength(13).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Details).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PublishYear).IsRequired(); 
            builder.Property(x => x.NumberOfPages).IsRequired(); 
            builder.Property(x => x.UnitPrice).HasPrecision(18, 2).IsRequired(); 
            builder.Property(x => x.ImageUri).IsRequired();
            builder.Property(x => x.Stock).IsRequired(); 
            builder.HasOne(x => x.Publisher).WithMany(x => x.Books).HasForeignKey(x => x.PublisherId);
            builder.HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
            builder.HasMany(x => x.Comments).WithOne(x => x.Book).HasForeignKey(x => x.ISBN);
        }
    }
}
