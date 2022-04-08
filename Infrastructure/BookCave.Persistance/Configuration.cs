using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BookCave.Persistance
{
    public static class Configuration
    {
        public static string GetMainConnectionString()
        {
            ConfigurationManager manager = new();
            var a = manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/BookCave.UI"));
            manager.AddJsonFile("appsettings.json");
            return manager.GetConnectionString("BookCaveDbContext");
        }
        public static string GetIdentityConnectionString()
        {
            ConfigurationManager manager = new();
            var a = manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/BookCave.UI"));
            manager.AddJsonFile("appsettings.json");
            return manager.GetConnectionString("IdentityBookCaveContext");
        }

    }
}