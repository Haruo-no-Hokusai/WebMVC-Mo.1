using Microsoft.EntityFrameworkCore;
using Code_First_Test.Models;

namespace Code_First_Test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlite("Data Source=TestDataBaseLite");
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=TestDataBase; Trusted_Connection=True; TrustServerCertificate=True");
        }
        public DbSet<Product> Products { get; set; }

    }
}
