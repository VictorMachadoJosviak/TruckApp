using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckApp.Validators.Truck;

namespace TruckApp.Web.Config
{
    public static class AppConfig
    {
        public static void AddControllersWithValidation(this IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateTruckValidator>());
        }
    }
}
