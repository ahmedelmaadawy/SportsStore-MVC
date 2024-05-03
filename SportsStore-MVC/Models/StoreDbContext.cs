using Microsoft.EntityFrameworkCore;

namespace SportsStore_MVC.Models
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products => Set<Product>();
    }
}
