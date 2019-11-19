using ApiNET.Extension;
using ApiNET.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;
using WebApiContrib.Core.Formatter.Bson;
using WebApiContrib.Core.Formatter.Csv;
using WebApiContrib.Core.Formatter.PlainText;

namespace ApiNET
{
    public class Startup
    {
        private static SymmetricSecurityKey _signingKey;
        private static JwtTokenConfiguration _jwtTokenConfiguration;

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

            //************* JWT Authentication

            _signingKey = new SymmetricSecurityKey(
                                Encoding.ASCII.GetBytes(Configuration["Authentication:JwtBearer:SecurityKey"]));

            _jwtTokenConfiguration = new JwtTokenConfiguration
            {
                Issuer = Configuration["Authentication:JwtBearer:Issuer"],
                Audience = Configuration["Authentication:JwtBearer:Audience"],
                SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(60),
            };

            services.Configure<JwtTokenConfiguration>(config =>
            {
                config.Audience = _jwtTokenConfiguration.Audience;
                config.EndDate = _jwtTokenConfiguration.EndDate;
                config.Issuer = _jwtTokenConfiguration.Issuer;
                config.StartDate = _jwtTokenConfiguration.StartDate;
                config.SigningCredentials = _jwtTokenConfiguration.SigningCredentials;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _jwtTokenConfiguration.Issuer,
                    ValidAudience = _jwtTokenConfiguration.Audience,
                    IssuerSigningKey = _signingKey
                };
            });

            // *************************** End of JWT Authentication


            services.AddEntityFrameworkSqlServer()
                   .AddDbContext<ApplicationDbContext>(options =>
                       options.UseSqlServer(Configuration.GetConnectionString("ApplicationDb"), sqlServerOptions =>
                       {
                           sqlServerOptions.UseRowNumberForPaging();
                       }));

            // Inject Application Options
            services.Configure<ApplicationOptions>(Configuration.GetSection("ApplicationOptions"));

            services.AddMvc()
                     // JSON serializer config
                     //.AddJsonOptions(options =>
                     //   options.SerializerSettings
                     //).
                     //.AddJsonOptions(opt =>
                     //{
                     //    // API json syntax
                     //    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                     //})
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

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ApiNET API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "https://example.com/terms",
                    Contact = new Contact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer",
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license",
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
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
            app.UseAuthentication();

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