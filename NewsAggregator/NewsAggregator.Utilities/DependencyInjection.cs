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

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRSSFeedService, RSSFeedService>();
            services.AddScoped<IAdService, AdService>();

            //Background services
            services.AddHostedService<RSSReaderBackgroundService>();

            //Repositories
         
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IRSSFeedRepository, RSSFeedRepository>();
            services.AddTransient<IAdRepository, AdRepository>();

            return services;
        }
    }
}
