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
            services.AddScoped<IAdService, AdService>();

            //Repositories
            //services.AddTransient<IRepository<User>, BaseRepository<User>>();
            //services.AddScoped<IRepository<Article>, BaseRepository<Article>>();
            //services.AddScoped<IRepository<Comment>, BaseRepository<Comment>>();
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IAdRepository, AdRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IRSSFeedService, RSSFeedService>();
            services.AddTransient<ICategoryService, CategoryService>();

            //Background services
            services.AddHostedService<RSSReaderBackgroundService>();

            //Repositories
            //services.AddTransient<IRepository<User>, BaseRepository<User>>();
            //services.AddTransient<IRepository<Article>, BaseRepository<Article>>();
            //services.AddTransient<IRepository<Comment>, BaseRepository<Comment>>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IRSSFeedRepository, RSSFeedRepository>();


            return services;
        }
    }
}
