using Microsoft.EntityFrameworkCore;

namespace ImageManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=ImageManagement; Trusted_Connection=True; TrustServerCertificate=True");
        }

        public DbSet<Product> products { get; set; }
    }
}
