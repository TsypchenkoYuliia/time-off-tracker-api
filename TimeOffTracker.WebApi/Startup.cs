using BusinessLogic.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimeOffTracker.WebApi.Filters;

namespace TimeOffTracker.WebApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            BusinessConfiguration.ConfigureServices(services, Configuration);

            services.AddControllers(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });

            services.AddScoped<ExceptionFilter>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //CORS setting
            app.UseCors(builder => builder.AllowAnyOrigin());
            //.WithOrigins(<front address>)
            //.AllowAnyMethod()
            //.AllowCredentials()

            app.UseMvc();
        }
    }
}
