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
            modelBuilder.Entity<ItemClient>().HasKey(ic => new 
            {
                ic.ItemId,
                ic.ClientId
            });
            modelBuilder.Entity<ItemClient>().HasOne(i => i.Item).WithMany(ic => ic.ItemClients).HasForeignKey(i => i.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(c => c.Client).WithMany(ic => ic.ItemClients).HasForeignKey(c => c.ClientId);

            // Seeder
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Item1", Price = 10.0, SerialNumberId = 1 }
                );

            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 1, Name = "SerialNumber1" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Category1" },
                new Category { Id = 2, Name = "Category2" }
                );

            base.OnModelCreating(modelBuilder);
        }

        // Entities
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemClient> ItemClients { get; set; }
    }
}
