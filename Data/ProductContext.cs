using eCommerceSitePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSitePractice.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
