using Microsoft.EntityFrameworkCore;
using SmartERPBackend.Models;

namespace SmartERPBackend.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Ledgers> Ledgers { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<StockItems> 
            StockItems { get; set; }
    }
}
