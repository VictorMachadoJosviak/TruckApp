using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TruckApp.Infra.Persistence;
using TruckApp.Infra.Transactions;
using TruckApp.Repository;
using TruckApp.Repository.Interfaces;
using TruckApp.Service;
using TruckApp.Service.Interfaces;

namespace TruckApp.IoC
{
    public static class DIManager
    {
        public static void InitializeContainer(this IServiceCollection services, IConfiguration configuration)
        {
            InitializeDataContext(services, configuration);
            InitializeRepositories(services);
            InitializeServices(services);
        }

        private static void InitializeServices(IServiceCollection services)
        {
            services.AddScoped<ITruckService, TruckService>();
            services.AddScoped<IModelService, ModelService>();
        }

        private static void InitializeRepositories(IServiceCollection services)
        {
            services.AddScoped<ITruckRepository, TruckRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
        }

        private static void InitializeDataContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration["DefaultConnection"]));
            services.AddScoped<DataContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
