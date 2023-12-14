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

        public DbSet<Products> Product { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
