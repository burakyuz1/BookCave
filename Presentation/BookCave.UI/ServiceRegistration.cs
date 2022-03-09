using BookCave.UI.Abstracts.Home;
using BookCave.UI.Abstracts.Shop;
using BookCave.UI.Concretes.Home;
using BookCave.UI.Concretes.Shop;
using Microsoft.Extensions.DependencyInjection;

namespace BookCave.UI
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection service)
        {
            service.AddScoped<IHomeService, HomeService>();
            service.AddScoped<IShopViewModelService, ShopViewModelService>();
        }
    }
}
