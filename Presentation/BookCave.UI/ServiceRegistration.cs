using BookCave.Application.Abstracts;
using BookCave.Application.Concretes;
using BookCave.UI.Abstracts;
using BookCave.UI.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace BookCave.UI
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection service)
        {
            service.AddScoped<ICartService, CartService>();
            service.AddScoped<IHomeViewModelService, HomeViewModelService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<ICommentService, CommentService>();
            service.AddScoped<IShopViewModelService, ShopViewModelService>();
            service.AddScoped<ICartViewModelService, CartViewModelService>();
            service.AddScoped<IOrderViewModelService, OrderViewModelService>();
            service.AddScoped<ISingleBookViewModelService, SingleBookViewModelService>();
            service.AddScoped<ICommentViewModelService, CommentViewModelService>();
        }
    }
}
