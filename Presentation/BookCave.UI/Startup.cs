using BookCave.Application.Abstracts.Home;
using BookCave.Application.Abstracts.Repository;
using BookCave.Persistance;
using BookCave.Persistance.EntityFramework;
using BookCave.Persistance.EntityFramework.EfRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookCave.Infrastructure;

namespace BookCave.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookCaveDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("BookCaveContext")));

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddInfrastructureServices();
            
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}"
            ));
        }
    }
}
