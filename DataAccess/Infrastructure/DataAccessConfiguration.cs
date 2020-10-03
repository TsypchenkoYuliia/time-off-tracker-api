using DataAccess.Context;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Infrastructure
{
    public class DataAccessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient(typeof(SignRepository));
            services.AddTransient(typeof(ApplicationRepository));
            services.AddTransient(typeof(UserRepository));
          
            //services.AddDbContext<VacationsContext>(option =>
                //option.UseSqlServer(configuration.GetConnectionString("defaultConnection")));

        }
    }
}
