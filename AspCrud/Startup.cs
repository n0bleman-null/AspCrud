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
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;
using DAL.Finders;

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
            services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(_configuration.GetSection("Redis").Get<RedisConfiguration>());
            services.AddDbContext<CryptoContext>(options => options.UseSqlServer(_configuration["ConnectionStrings:CryptoConnection"]));
            services.AddScoped<DbSet<Crypto>>(provider => provider.GetRequiredService<CryptoContext>().Cryptos);
            services.AddScoped<ICryptoFinder, CryptoRedisFinder>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICryptoRepository, CryptoDbRedisRepository>();
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
