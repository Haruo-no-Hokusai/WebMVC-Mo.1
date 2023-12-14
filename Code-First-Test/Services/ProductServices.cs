using Code_First_Test.Data;
using Code_First_Test.Models;


namespace Code_First_Test.Services
{
    public class ProductServices : IProductServices
    {
        private readonly DataContext db;
        List<Product> products;
        public ProductServices(DataContext _db) 
        {
            db = _db;
            products = new List<Product>();
            if( db.Products.Count() == 0 ) GenerateProduct();
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delate(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void GenerateProduct(int num=10)
        {
            Random random = new Random();
            for (int i = 0; i < num; i++)
            {
                products.Add(new Product
                {
                    Name = $"Test{i}",
                    Price = random.Next(100,1000),
                    Amount = random.Next(10,100),
                });
                
            }
            db.Products.AddRange(products);
            db.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.OrderByDescending(p => p.Id).ToList();
        }

        public Product GetById(int id)
        {
            var product = db.Products.Find(id);
            return product;
        }

        public void UpdateProduct(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
        }
    }
}
