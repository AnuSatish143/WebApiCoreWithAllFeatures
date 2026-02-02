using Microsoft.EntityFrameworkCore;
using WebApiCoreWithAllFeatures.Models;
namespace WebApiCoreWithAllFeatures.Data
{
    public class AppDbContext  : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> products { get; set; }  
        public DbSet<User> users { get; set; }

    }
}
