using BookCave.Application.Abstracts.Home;
using BookCave.Infrastructure.Concretes.Home;
using Microsoft.Extensions.DependencyInjection;

namespace BookCave.Infrastructure
{
    public static class ServiceRegistration 
    {
        public static void AddInfrastructureServices(this IServiceCollection service)
        {
            service.AddScoped<IHomeService, HomeService>();
        }

    }
}
