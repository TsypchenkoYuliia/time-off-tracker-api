using BusinessLogic.Services;
using DataAccess.Context;
using DataAccess.Infrastructure;
using Domain.EF_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Infrastructure
{
    public static class BusinessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {            
            services.AddTransient(typeof(TimeOffRequestService));

            DataAccessConfiguration.ConfigureServices(services, configuration);
        }
        public static async Task ConfigureIdentityInicializerAsync(IServiceProvider provider)
        {
            var userManager = provider.GetRequiredService<UserManager<User>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            await new IdentityInitializer(userManager, roleManager).SeedAsync();
        }
    }
}
