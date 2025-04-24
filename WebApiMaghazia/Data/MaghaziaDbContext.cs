using Microsoft.EntityFrameworkCore;
using WebApiMaghazia.Models;

namespace WebApiMaghazia.Data
{
    public class MaghaziaDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MaghaziaDbContext(DbContextOptions<MaghaziaDbContext> options) : base(options)
        {
            
        }

    }
}
