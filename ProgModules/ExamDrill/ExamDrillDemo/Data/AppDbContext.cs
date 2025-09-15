using ExamDrillDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamDrillDemo.Data {
    internal class AppDbContext : DbContext {

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<ItemTag> ItemTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public AppDbContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Item)
                .WithMany(i => i.Notes)
                .HasForeignKey(n => n.ItemId);

            modelBuilder.Entity<ItemTag>()
                .HasKey(it => it.Id);

            modelBuilder.Entity<ItemTag>()
                .HasOne(it => it.Item)
                .WithMany(i => i.ItemTags)
                .HasForeignKey(it => it.ItemId);

            modelBuilder.Entity<ItemTag>()
                .HasOne(it => it.Tag)
                .WithMany(t => t.ItemTags)
                .HasForeignKey(it => it.TagId);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Title = "abobus" }
            );

            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "lol" },
                new Tag { Id = 2, Name = "kek" },
                new Tag { Id = 3, Name = "4eburek" }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "aboba", CategoryId = 1 }
            );

            modelBuilder.Entity<Note>().HasData(
                new Note { Id = 1, Text = "haha", ItemId = 1 },
                new Note { Id = 2, Text = "ohoh", ItemId = 1 }
            );

            modelBuilder.Entity<ItemTag>().HasData(
                new ItemTag { Id = 1, ItemId = 1, TagId = 1 },
                new ItemTag { Id = 2, ItemId = 1, TagId = 2 },
                new ItemTag { Id = 3, ItemId = 1, TagId = 3 }
            );
        }
    }
}
