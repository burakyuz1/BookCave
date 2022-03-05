using BookCave.Application.Abstracts.Repository;
using BookCave.Persistance.EntityFramework;
using BookCave.Persistance.EntityFramework.EfRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookCave.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<BookCaveDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("BookCaveContext")));
            service.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        }
    }
}
