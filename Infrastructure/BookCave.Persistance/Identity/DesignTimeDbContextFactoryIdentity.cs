using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookCave.Persistance.Identity
{
    public class DesignTimeDbContextFactoryIdentity : IDesignTimeDbContextFactory<IdentityBookCaveDbContext>
    {
        public IdentityBookCaveDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<IdentityBookCaveDbContext> builder = new();
            builder.UseSqlServer(Configuration.GetIdentityConnectionString());
            return new(builder.Options);
        }
    }
}