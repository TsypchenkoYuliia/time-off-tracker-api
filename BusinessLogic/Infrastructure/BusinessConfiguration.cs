using BusinessLogic.Services;
using DataAccess.Infrastructure;
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
            services.AddTransient(typeof(TimeOffRequestService));

            DataAccessConfiguration.ConfigureServices(services, configuration);
        }
    }
}
