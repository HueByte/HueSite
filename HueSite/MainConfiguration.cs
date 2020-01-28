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
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Identity;
using HueSite.Areas.Identity;
using HueSite.Data.Services;
using HueSite.Data.IServices;
using HueSite.Data.IServices.ISortingAlg;
using HueSite.Data.Services.SortingAlg;
using HueSite.Areas.Identity.Data;
using HueSite.Data.Models;

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
            services.AddDefaultIdentity<AppUser>(config =>
            {
                config.SignIn.RequireConfirmedEmail = false;
                config.User.RequireUniqueEmail = true;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();

            services.AddBlazoredSessionStorage();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<AppUser>>();
            services.AddScoped<IAdmin, Admin>();

            //Sorting algs
            services.AddScoped<ISorting, Sorting>();
        }
        
        public void ConfigureContext()
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(conf.GetConnectionString("HueDatabase")));
        }
    }
}
