using Microsoft.EntityFrameworkCore;
using VendorManagement.Models;

namespace VendorManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles>Roles { get; set; }

    }
}

