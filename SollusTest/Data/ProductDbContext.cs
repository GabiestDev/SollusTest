using Microsoft.EntityFrameworkCore;
using SollusTest.Models.Entities;

namespace SollusTest.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Storage> Storage { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Data Source=product.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(x => x.Storage)
                .WithOne()
                .HasForeignKey<Storage>(x => x.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
