using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess
{
    public class NewsAggregatorDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public NewsAggregatorDbContext(DbContextOptions<NewsAggregatorDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User("Bob", "Bobsky", "bBobsky", "bob@email.com", PasswordHasher.HashPassword("password123")) { Id = 1 },
                new User("Jon", "Doe", "jDoe", "john.doe@email.com", PasswordHasher.HashPassword("password123")) { Id = 2 },
                new User("Tom", "Admin", "adminTom", "tom@admin.com", PasswordHasher.HashPassword("admin123")) { Id = 3, IsAdmin = true },
                new User("Jill", "Admin", "adminJill", "jill@admin.com", PasswordHasher.HashPassword("admin123")) { Id = 4, IsAdmin = true }
                );

            builder.Entity<Article>().HasData(
                new Article("test", "test",
                "https://cdn.theathletic.com/cdn-cgi/image/width=770,format=auto/https://cdn.theathletic.com/app/uploads/2022/09/07021831/ERLING-HAALAND-MANCHESTER-CITY-scaled-e1662531544452-1024x683.jpg",
                "https://theathletic.com/3571283/2022/09/07/manchester-city-erling-haaland-one-touch/", "https://theathletic.com", "https://theathletic.com/app/themes/athletic/assets/img/open-graph-asset.png", "testestestestestes", DateTime.Now)
                { Id=1});

            builder.Entity<User>(x => x.ToTable("User"));
        }
    }
}