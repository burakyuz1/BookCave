using BookCave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCave.Persistance.Configurations
{
    public class CategoryDetailConfig : IEntityTypeConfiguration<CategoryDetail>
    {
        public void Configure(EntityTypeBuilder<CategoryDetail> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.ISBN });
            builder.HasOne(x => x.Category).WithMany(x => x.CategoryDetails).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Book).WithMany(x => x.CategoryDetails).HasForeignKey(x => x.ISBN);
        }
    }
}
