using BookTurf.Repository;
using BookTurf.Repository.Interfaces;
using BookTurf.Services;
using BookTurf.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookTurf.Web.BuilderExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            //Resister your Repositories Here
            services.AddScoped(typeof(ICategoryMasterRepository), typeof(CategoryMasterRepository));
            services.AddScoped(typeof(ILoginRepository), typeof(LoginRepository));



            //Resister your Services Here
            services.AddScoped(typeof(ICategoryMasterService), typeof(CategoryMasterService));
            services.AddScoped(typeof(ILoginService), typeof(LoginService));

            return services;
        }
    }
}
