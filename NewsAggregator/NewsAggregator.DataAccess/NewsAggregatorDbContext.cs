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
        public DbSet<Ad> Ads { get; set; )

        public DbSet<RSSFeed> RssFeeds { get; set; }

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

            builder.Entity<Category>().HasData(
                    new Category("Politics") { Id = 1 },
                    new Category("Business") { Id = 2 },
                    new Category("Science") { Id = 3 },
                    new Category("Tech") { Id = 4 },
                    new Category("Gaming") { Id = 5 },
                    new Category("Showbiz") { Id = 6 },
                    new Category("Sport") { Id = 7 },
                    new Category("Other") { Id = 8 }
                );

            builder.Entity<RSSFeed>().HasData(

                new RSSFeed("Fox news - bussines", "https://moxie.foxnews.com/google-publisher/politics.xml", 1) { Id = 1 },
                new RSSFeed("Fox news - science", "https://moxie.foxnews.com/google-publisher/science.xml", 3) { Id = 2 },
                new RSSFeed("Fox news - technology", "https://moxie.foxnews.com/google-publisher/tech.xml", 4) { Id = 3 },
                new RSSFeed("Fox news - sports", "https://moxie.foxnews.com/google-publisher/sports.xml", 7) { Id = 4 },
                new RSSFeed("Fox news - travel", " https://moxie.foxnews.com/google-publisher/travel.xml", 8) { Id = 5 },
                new RSSFeed("Fox news - health", " https://moxie.foxnews.com/google-publisher/health.xml", 8) { Id = 6 },

                new RSSFeed("New York Times - bussines", "https://rss.nytimes.com/services/xml/rss/nyt/Business.xml", 2) { Id = 7 },
                new RSSFeed("New York Times - science", "https://rss.nytimes.com/services/xml/rss/nyt/Science.xml", 3) { Id = 8 },
                new RSSFeed("New York Times - tehcnology", "https://rss.nytimes.com/services/xml/rss/nyt/Technology.xml", 4) { Id = 9 },
                new RSSFeed("New York Times - sports", "https://rss.nytimes.com/services/xml/rss/nyt/Sports.xml", 7) { Id = 10 },
                new RSSFeed("New York Times - health", "https://rss.nytimes.com/services/xml/rss/nyt/Health.xml", 8) { Id = 11 },
                new RSSFeed("New York Times - travel", "https://rss.nytimes.com/services/xml/rss/nyt/Travel.xml", 8) { Id = 12 }

                );


            builder.Entity<Ad>().HasData(
                new Ad("https://www.somagnews.com/wp-content/uploads/2021/12/Netflix-1.jpg", "https://www.netflix.com/mk/", "Netflix", true) { Id = 1 });


            builder.Entity<User>(x => x.ToTable("User"));
            builder.Entity<Article>(x => x.ToTable("Article"));
            builder.Entity<Ad>(x => x.ToTable("Ad"));
            builder.Entity<Comment>(x => x.ToTable("Comment"));
            builder.Entity<Category>(x => x.ToTable("Category"));
            builder.Entity<RSSFeed>(x => x.ToTable("RSSFeed"));


        }
    }
}