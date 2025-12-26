using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TESTAPI.Models;

namespace TESTAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
          

        }

        public DbSet<Product>Products { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

    }

}
