using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing;
using DAL;
using DAL.Repositories;
using BLL.Repositories;
using BLL.Entities;
using BLL.Services;
using Microsoft.EntityFrameworkCore;
using AspCrud.Requests;
using AutoMapper;

namespace AspCrud
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CryptoContext>(options => options.UseSqlServer("name=ConnectionStrings:CryptoConnection"));
            services.AddScoped<IRepository<Crypto>, CryptoDbRepository>();
            services.AddScoped<CryptoService>();
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
