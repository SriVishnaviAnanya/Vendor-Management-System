using Microsoft.EntityFrameworkCore;
using Dev_2.Models;

namespace Dev_2.Data
{
    public class AppDbContext : DbContext
    {
        // ✅ THIS CONSTRUCTOR IS REQUIRED
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }
    }
}