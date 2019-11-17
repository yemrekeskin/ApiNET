﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNET.Extension;
using ApiNET.Middleware;
using ApiNET.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiContrib.Core.Formatter.Bson;
using WebApiContrib.Core.Formatter.Csv;
using WebApiContrib.Core.Formatter.PlainText;

namespace ApiNET
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Inject Application Options
            services.Configure<ApplicationOptions>(Configuration.GetSection("ApplicationOptions"));

            services.AddEntityFrameworkSqlServer()
                   .AddDbContext<ApplicationDbContext>(options =>
                       options.UseSqlServer(Configuration.GetConnectionString("ApplicationDb"), sqlServerOptions =>
                       {
                           sqlServerOptions.UseRowNumberForPaging();
                       }));

            services.AddMvc()
                     .AddCsvSerializerFormatters() // api csv output
                     .AddPlainTextFormatters() // api plain text output
                     .AddBsonSerializerFormatters() // api BSON output
                     .AddXmlSerializerFormatters() // api XML output                     
                     .AddFluentValidation() // api service model validation
                     .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            // Versioning
            services.AddApiVersioning();

            // Dependency Profile
            services.DependencyLoad();
            
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //Add our new middleware to the pipeline
            // web api request-response logging
            //app.UseMiddleware<LoggingMiddleware>();
            app.UseIPFilter();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
