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
    public static class DataAccessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient(typeof(SignRepository));
            services.AddTransient(typeof(ApplicationRepository));
            services.AddTransient(typeof(UserRepository));

            services.AddDbContext<VacationsContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("defaultConnection"))); // add to web appsettings "connectionStrings": {
            //"defaultConnection": "Data Source=SQL5080.site4now.net;Initial Catalog=DB_A685D8_Test;User Id=DB_A685D8_Test_admin;Password=qwerty123456"},

        }
    }
}
