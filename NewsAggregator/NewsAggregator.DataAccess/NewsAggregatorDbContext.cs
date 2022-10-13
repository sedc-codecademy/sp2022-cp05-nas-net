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
        public DbSet<Ad> Ads { get; set; }

        public DbSet<RSSFeed> RssFeeds { get; set; }

        public NewsAggregatorDbContext(DbContextOptions<NewsAggregatorDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Ad>().HasData(
                new Ad("Netflix", "https://variety.com/wp-content/uploads/2019/03/netflix-logo-n-icon.png", "https://res.cloudinary.com/practicaldev/image/fetch/s--THrf5Yjw--/c_imagga_scale,f_auto,fl_progressive,h_420,q_auto,w_1000/https://dev-to-uploads.s3.amazonaws.com/uploads/articles/n6brz4p7iq7j1mulo1nv.jpg", "https://www.netflix.com") { Id = 1 },
                new Ad("Hbo", "https://s3.amazonaws.com/media.mediapost.com/dam/cropped/2021/06/02/hbomax-plansstartat999-600_4vXDoJJ.jpg", "https://cdnb.artstation.com/p/assets/images/images/027/198/593/large/mikhail-villarreal-bannerhbodceu-byalde.jpg?1590863405", "https://www.hbomax.com/") { Id = 2 },
                new Ad("Nike", "https://www.marketing91.com/wp-content/uploads/2020/06/Growth-of-Nike-Advertising.jpg", "https://uploads-ssl.webflow.com/5e72757e442fcb191b4823c0/5ea8b5ddeffbba465d0d010f_nike-lunar3.jpg", "https://www.nike.com/") { Id = 3 },
                new Ad("Razer Huntsman V2", "https://g-h.sgp1.digitaloceanspaces.com/wp-content/uploads/2021/10/11105246/RAZER-LANDING-PAGE_1TOP-BANNER-MOB-copy-5-800x800.png", "https://assets2.razerzone.com/images/pnx.assets/1ab71e5ea9f9b8db8fc014cf8d767732/razer-huntsman-v2-hero-desktop.jpg", "https://www.razer.com/gaming-keyboards/razer-huntsman-v2") { Id = 4 },
                new Ad("WizzAir", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/d9b02f1619767.560d88eed515a.jpg", "https://pbs.twimg.com/media/DdT-s6NW4AAEOEi.jpg", "https://wizzair.com/en-gb") { Id = 5 },
                new Ad("Asus ROG strix", "https://cdn.dribbble.com/users/5349551/screenshots/12021171/media/99c46cd52abd90cf754f5d0bba81f08b.png?compress=1&resize=400x300", "https://dlcdnwebimgs.asus.com/gain/F9741FD2-725D-4134-B0EB-C3E6F0FA7FF0/fwebp", "https://rog.asus.com/my/laptops/rog-strix/rog-strix-scar-17-2022-series/") { Id = 6 }
                );

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


            builder.Entity<User>(x => x.ToTable("User"));
            builder.Entity<Article>(x => x.ToTable("Article"));
            builder.Entity<Ad>(x => x.ToTable("Ad"));
            builder.Entity<Comment>(x => x.ToTable("Comment"));
            builder.Entity<Category>(x => x.ToTable("Category"));
            builder.Entity<RSSFeed>(x => x.ToTable("RSSFeed"));
        }
    }
}