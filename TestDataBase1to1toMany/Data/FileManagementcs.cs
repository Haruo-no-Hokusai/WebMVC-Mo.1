using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;

namespace TestDataBase1to1toMany.Data
{
    public class FileManagementcs : DbContext
    {
        public FileManagementcs() 
        {
                    
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=10.103.0.17,1433;" +
                "Database=HaruoDatabasetestNoI;" +
                "Trusted_Connection=false;MultipleActiveResultSets=true;" +
                "TrustServerCertificate=True;" +
                " User Id=student;" +
                " Password=Pass@sql;" +
                "Encrypt=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Primary key

            modelBuilder.Entity<ComponentToProduct>().HasKey(k=>new {k.ProductsId,k.ComponentId});

            //modelBuilder.Entity<ComponentToProduct>()
            //    .HasKey(pc => new { pc.ProductsId, pc.ComponentId });

            //modelBuilder.Entity<ComponentToProduct>()
            //    .HasOne(pc => pc.Products)
            //    .WithMany(p => p.Connection)
            //    .HasForeignKey(pc => pc.ProductsId);

            //modelBuilder.Entity<ComponentToProduct>()
            //    .HasOne(pc => pc.Component)
            //    .WithMany(c => c.Connection)
            //    .HasForeignKey(pc => pc.ComponentId);
        }

        public DbSet<Products> Product { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<ComponentToProduct> ComponentToProduct { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
    }
}
