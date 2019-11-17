using ApiNET.Controllers;
using ApiNET.Models;
using ApiNET.Repository;
using ApiNET.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET
{
    public static class DependencyProfile
    {
        public static void DependencyLoad(this IServiceCollection services)
        {
            // Customer
            services.AddScoped<IRepository<Customer>, Repository<Customer, ApplicationDbContext>>();
            services.AddScoped<ICustomerService, CustomerService>();

            // Address
            services.AddScoped<IRepository<Address>, Repository<Address, ApplicationDbContext>>();
            services.AddScoped<IAddressService, AddressService>();
            
            // Phone
            services.AddScoped<IRepository<Phone>, Repository<Phone, ApplicationDbContext>>();
            services.AddScoped<IPhoneService, PhoneService>();

            // Email
            services.AddScoped<IRepository<Email>, Repository<Email, ApplicationDbContext>>();
            services.AddScoped<IEmailService, EmailService>();

            // External
            services.AddScoped<IApiService, ApiService>();

            // Validators
            services.AddSingleton<IValidator<CustomerCreate>, CustomerCreateValidator>();

            // cache
            services.AddSingleton<ICacheService, CacheService>();
        }
    }
}
