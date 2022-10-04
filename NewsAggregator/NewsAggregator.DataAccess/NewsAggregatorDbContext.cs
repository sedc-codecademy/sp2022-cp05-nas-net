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

            builder.Entity<User>(x => x.ToTable("User"));
        }
    }
}
