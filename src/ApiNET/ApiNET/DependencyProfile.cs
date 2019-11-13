using ApiNET.Models;
using ApiNET.Repository;
using ApiNET.Services;
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
            services.AddScoped<IRepository<Customer>, Repository<Customer, ApplicationDbContext>>();
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
