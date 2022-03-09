using BookCave.BookCave.UI.Abstracts.Home;
using BookCave.BookCave.UI.Abstracts.Shop;
using BookCave.BookCave.UI.Concretes.Home;
using BookCave.BookCave.UI.Concretes.Shop;
using Microsoft.Extensions.DependencyInjection;

namespace BookCave.UI
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection service)
        {
            service.AddScoped<IHomeService, HomeService>();
            service.AddScoped<IAuthorService, AuthorService>();
            service.AddScoped<IPublisherService, PublisherService>();
            service.AddScoped<IBookCategoryService, BookCategoryService>();
        }
    }
}
