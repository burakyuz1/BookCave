using BookCave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCave.Persistance.Configurations
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(255);
        }
    }
}
