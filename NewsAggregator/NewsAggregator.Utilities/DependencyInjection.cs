﻿using Microsoft.EntityFrameworkCore;
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

            //Repositories
            //services.AddTransient<IRepository<User>, BaseRepository<User>>();
            //services.AddScoped<IRepository<Article>, BaseRepository<Article>>();
            //services.AddScoped<IRepository<Comment>, BaseRepository<Comment>>();
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}
