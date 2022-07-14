using Microsoft.EntityFrameworkCore;

namespace sasoft_back.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
