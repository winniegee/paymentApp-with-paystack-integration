using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using HelperClass;
using Infrastructuree.Data;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Providers;

namespace Suppliers_Payment
{
    public class Startup
    {
        public IConfiguration config;
        public Startup(IConfiguration config)
        {
           this.config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyHeader()
                    .WithOrigins("http://localhost:4200")
                        //builder => builder.AllowAnyOrigin()
                        .WithMethods("GET", "PUT", "POST", "PATCH", "DELETE", "OPTIONS")
                        .AllowCredentials());
            });
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            services.Configure<MvcOptions>(options =>
            options.Filters.Add(new CorsAuthorizationFilterFactory("CorsPolicy")));
            services.AddDbContext<BakeryContext>(cfg =>
            {
                cfg.UseSqlServer(config.GetConnectionString("BakeryContext")).EnableSensitiveDataLogging();
            });
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IRepository<Suppliers>), typeof(Repository<Suppliers>));
            services.AddTransient(typeof(IPaystack), typeof(Paystack));
            var appSettingsSection = config.GetSection("Appsettings");
            services.Configure<Appsettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<Appsettings>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");
            app.Use(async (context, next) =>
            {
                context.Response.Headers["Access-Control-Allow-Origin"] = "http://localhost:4200";
                await next();
                if (context.Response.StatusCode == 404 &&
                !Path.HasExtension(context.Request.Path.Value) &&
                    !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDefaultFiles();
                app.UseStaticFiles();
                app.UseMvc(cfg =>
                {
                    cfg.MapRoute("Default",
                        "{controller}/{action}/{id?}",
                        new { controller = "Home", Action = "Home" });

                });
                app.UseHttpsRedirection();
            }

           
           

        }
    }
}
