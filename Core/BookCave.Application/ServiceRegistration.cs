using BookCave.Application.Abstracts;
using BookCave.Application.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection service)
        {
           // service.AddScoped<ICartService, CartService>();
        }
    }
}
