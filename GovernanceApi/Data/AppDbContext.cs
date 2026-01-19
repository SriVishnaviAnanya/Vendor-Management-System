using GovernanceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GovernanceApi.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ComplianceChecklist> ComplianceChecklists { get; set; }
        public DbSet<NonComplianceLog> NonComplianceLogs { get; set; }
        public DbSet<VendorPerformance> VendorPerformances { get; set; }
        public object Vendors { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComplianceChecklist>(entity =>
            {
                entity.HasKey(e => e.ComplianceId);
                entity.Property(e => e.ComplianceStatus)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.LastReviewDate)
                    .HasDefaultValueSql("GETDATE()");
                entity.HasIndex(e => e.VendorId);
            });

            modelBuilder.Entity<NonComplianceLog>(entity =>
            {
                entity.HasKey(e => e.NonComplianceId);
                entity.Property(e => e.Reason)
                    .HasMaxLength(1000)
                    .IsRequired();
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("GETDATE()");
                entity.HasIndex(e => e.VendorId);
                entity.HasIndex(e => e.ContractId);
            });

            modelBuilder.Entity<VendorPerformance>(entity =>
            {
                entity.HasKey(e => e.PerformanceId);
                entity.Property(e => e.SLARemarks)
                    .HasMaxLength(1000);
                entity.Property(e => e.SLARatedDate)
                    .HasDefaultValueSql("GETDATE()");
                entity.HasIndex(e => e.VendorId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
