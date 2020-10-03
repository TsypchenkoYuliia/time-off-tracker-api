using BusinessLogic.Services;
using DataAccess.Infrastructure;
using DataAccess.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Infrastructure
{
    public static class BusinessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            //services
            services.AddTransient(typeof(ApplicationService));

            DataAccessConfiguration.ConfigureServices(services, configuration);
        }
    }
}
