using BookCave.Application.Abstracts;
using BookCave.Application.Concretes;
using BookCave.UI.Abstracts.Cart;
using BookCave.UI.Abstracts.Home;
using BookCave.UI.Abstracts.Order;
using BookCave.UI.Abstracts.Shop;
using BookCave.UI.Concretes.Carts;
using BookCave.UI.Concretes.Home;
using BookCave.UI.Concretes.Orders;
using BookCave.UI.Concretes.Shop;
using Microsoft.Extensions.DependencyInjection;

namespace BookCave.UI
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection service)
        {
            service.AddScoped<ICartService, CartService>();
            service.AddScoped<IHomeService, HomeService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<IShopViewModelService, ShopViewModelService>();
            service.AddScoped<ICartViewModelService, CartViewModelService>();
            service.AddScoped<IOrderViewModelService, OrderViewModelService>();
        }
    }
}
