using Microsoft.EntityFrameworkCore;
using MyWebApplication.Models;

namespace MyWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Item1", Price = 10.0, SerialNumberId = 1 }
                );

            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 1, Name = "SerialNumber1" }
                );

            base.OnModelCreating(modelBuilder);
        }

        // Entities
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
    }
}
