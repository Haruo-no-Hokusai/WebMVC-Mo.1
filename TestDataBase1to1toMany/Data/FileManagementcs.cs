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
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=TestonoToontToMany; Trusted_connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Primary key
            modelBuilder.Entity<ComponentToProduct>().HasKey(k=>new {k.ProductsId,k.ComponentId});
        }

        public DbSet<Products> Product { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<ComponentToProduct> ComponentToProduct { get; set; }
    }
}
