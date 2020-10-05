using DataAccess.Context;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using Domain.EF_Models;
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

            services.AddTransient(typeof(TimeOffRequestRepository));
            services.AddTransient(typeof(TimeOffRequestReviewRepository));
            services.AddTransient(typeof(UserRepository));

            services.AddDbContext<TimeOffTrackerContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("defaultConnection"))); // add to web appsettings "connectionStrings": {
            //"defaultConnection": "Data Source=SQL5080.site4now.net;Initial Catalog=DB_A685D8_Test;User Id=DB_A685D8_Test_admin;Password=qwerty123456"},

        }
    }
}
