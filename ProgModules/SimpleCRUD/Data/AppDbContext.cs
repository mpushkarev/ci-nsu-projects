using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Models;

namespace SimpleCRUD.Data {
    internal class AppDbContext : DbContext {

        public DbSet<Item> Items { get; set; }

        public AppDbContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Item>();

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "biba", CreatedAt = new DateTime(2025, 12, 1, 12, 0, 0) },
                new Item { Id = 2, Name = "boba", CreatedAt = new DateTime(2025, 12, 2, 13, 0, 0) },
                new Item { Id = 3, Name = "aboba", CreatedAt = new DateTime(2025, 12, 3, 14, 0, 0) }
            );
        }
    }
}
