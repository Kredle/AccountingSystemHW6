using AccountingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingSystem.Data
{
    public class AcountingDbContext : DbContext
    {
        public AcountingDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseCategory> PurchasesCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount).IsRequired();

                entity.Property(e => e.Comment).HasMaxLength(250);

                entity.Property(p => p.Amount).HasPrecision(18, 2);

                entity.HasOne(e => e.Category).WithMany(c => c.Purchases).HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}