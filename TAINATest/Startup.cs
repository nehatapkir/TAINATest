using Infrastructure.Model;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TAINATest.Model;
using TAINATest.Repository;
using TAINATest.ProfileMapping;
using TAINATest.Filters;

namespace TAINATest
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddDbContext<PersonDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddResponseCaching();
            services.AddTransient<IRepository<Person>, PersonRepository>();     
            services.AddAutoMapper(typeof(PersonProfileMapping));
            services.AddMediatR(typeof(Startup));
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddCors(); // Make sure you call this previous to AddMvc
            services.AddControllers().AddNewtonsoftJson();

            services.AddScoped<ExceptionLoggingFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.EnvironmentName == "development")
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(
       options => options.WithOrigins("http://localhost:8080/").AllowAnyMethod()
   );
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); //Routes for pages
                endpoints.MapControllers(); //Routes for my API controllers
            });
            app.UseResponseCaching();
       
        }
    }
}
