using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Persistance.Identity
{
    public class IdentityBookCaveDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityBookCaveDbContext(DbContextOptions<IdentityBookCaveDbContext> options) : base(options)
        {
        }
    }
}
