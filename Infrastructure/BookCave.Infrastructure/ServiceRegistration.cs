using BookCave.Application.Abstracts.Home;
using BookCave.Application.Abstracts.Shop;
using BookCave.Infrastructure.Concretes.Home;
using BookCave.Infrastructure.Concretes.Shop;
using Microsoft.Extensions.DependencyInjection;

namespace BookCave.Infrastructure
{
    public static class ServiceRegistration 
    {
        public static void AddInfrastructureServices(this IServiceCollection service)
        {
            service.AddScoped<IHomeService, HomeService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IAuthorService, AuthorService>();
            service.AddScoped<IPublisherService, PublisherService>();
            service.AddScoped<IBookCategoryService, BookCategoryService>();
        }

    }
}
