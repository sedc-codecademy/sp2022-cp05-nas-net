using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.DataAccess.Repositories;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Services.Abstraction;
using NewsAggregator.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterModule(this IServiceCollection services)
        {
            //Services
            services.AddTransient<IPlaceholderService, PlaceholderService>();

            //Repositories
            services.AddTransient<IRepository<Placeholder>, PlaceholderStaticRepository>();

            return services;
        }
    }
}
