using System;
using ECommerce.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ECommerce
{
    public class Startup
    {
        public IConfiguration HamsterWheel { get; private set; }
        public Startup(IHostingEnvironment env){
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("trashfile.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            HamsterWheel = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<Hamster, IdentityRole>().AddEntityFrameworkStores<HammyContext>().AddDefaultTokenProviders();
            services.AddDbContext<HammyContext>(foodbag => foodbag.UseMySQL(HamsterWheel["HamsterCheeks:SunflowerSeed"]));
            services.AddMvc();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseIdentity();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
        }
    }
}
