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
using Microsoft.Extensions.Configuration;

namespace AspCrud
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // need I inject database congig?
            services.AddDbContext<CryptoContext>(options => options.UseSqlServer(_configuration["ConnectionStrings:CryptoConnection"]));
            services.AddScoped<DbSet<Crypto>>(provider => provider.GetRequiredService<CryptoContext>().Cryptos);
            services.AddScoped<IFinder<Crypto>, Finder<Crypto>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Crypto>, CryptoDbRepository>();
            services.AddScoped<ICryptoService, CryptoService>();
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
