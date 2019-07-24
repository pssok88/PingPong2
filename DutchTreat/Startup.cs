﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DutchTreat
{

    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DutchContext>(cfg => {
                cfg.UseSqlServer(_config.GetConnectionString("DutchConnectionString"));
            });

            services.AddAutoMapper();

            services.AddTransient<DutchSeeder>();
            services.AddTransient<IMailService, NullMailService>();
            // support for real mail service

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();

            services.AddMvc()
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            //app.UseDefaultFiles(); // this looks for index.html file or similar default and pass it

            //app.UseDeveloperExceptionPage();
            app.UseStaticFiles(); // this grabs the url found and renders
            app.UseNodeModules(env);

            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default", "/{controller}/{action}/{id?}", 
                    new { controller = "App", Action = "Index" });
            });
        }
    }
}
