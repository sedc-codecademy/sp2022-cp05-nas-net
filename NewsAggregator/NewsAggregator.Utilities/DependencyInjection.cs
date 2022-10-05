using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.DataAccess;
using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.DataAccess.Repositories;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Services.Abstraction;
using NewsAggregator.Services.Implementation;

namespace NewsAggregator.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterModule(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NewsAggregatorDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            //Services
            services.AddTransient<IUserService, UserService>();

            //Repositories
            services.AddTransient<IRepository<User>, UserRepository>();

            return services;
        }
    }
}
