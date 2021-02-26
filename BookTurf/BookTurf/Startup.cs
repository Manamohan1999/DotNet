using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTurf.Data.Models;
using Microsoft.EntityFrameworkCore;
using BookTurf.Web.MiddleWare;
using BookTurf.Web.BuilderExtensions;

namespace BookTurf
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddDirectoryBrowser();
            // Add framework services.
            services.AddMvc(option => option.EnableEndpointRouting = false);
            //services.AddNodeServices();
            //services.AddControllers().AddNewtonsoftJson();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromDays(30);
            });

            services.AddControllersWithViews();
            services.AddDbContext<BookTurfContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BookTurfContext"), Aoptions => Aoptions.CommandTimeout(180)).EnableSensitiveDataLogging());

            services.AddDependencies();

            //services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
            
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "/{controller=Login}/{action=Index}/{id?}");
            });

        }
    }
}
