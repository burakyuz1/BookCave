using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookCave.Persistance.EntityFramework
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BookCaveDbContext>
    {
        public BookCaveDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<BookCaveDbContext> contextOptionsBuilder = new();
            contextOptionsBuilder.UseSqlServer(Configuration.GetMainConnectionString());
            return new(contextOptionsBuilder.Options);
        }
    }
}