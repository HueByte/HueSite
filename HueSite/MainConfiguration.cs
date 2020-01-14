using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HueSite.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;
using HueSite.Data;
using Blazored.SessionStorage;

namespace HueSite
{
    public class MainConfiguration
    {
        IServiceCollection services;
        IConfiguration conf;
        public MainConfiguration(IServiceCollection _services, IConfiguration _conf)
        {
            services = _services;
            conf = _conf;
        }

        public void ConfigureCustomServices()
        {
            services.AddScoped<AuthenticationStateProvider, Data.CustomAuthenticationStateProvider>();
            services.AddBlazoredSessionStorage();
        }
        
        public void ConfigureContext()
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(conf.GetConnectionString("HueDatabase")));
        }
    }
}
