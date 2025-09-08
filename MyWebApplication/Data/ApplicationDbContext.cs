using Microsoft.EntityFrameworkCore;
using MyWebApplication.Models;

namespace MyWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        // Entities
        public DbSet<Item> Items { get; set; }
    }
}
