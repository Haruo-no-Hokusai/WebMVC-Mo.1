using MVC_Concept.Models.Settings;

namespace MVC_Concept.Models
{
    public class ProductService : IProductService
    {
        public List<Product> ProductList { get; set; }
        public ProductService() 
        {
            ProductList = new List<Product>();
        }
        public void GenerateProduct(int number=10)
        {
            Random random = new Random();
            var numberofproduct = NameOfProduct.ProductNames.Count;
            for(int i = 1; i <= number; i++)
            {
                ProductList.Add(new Product
                {
                    Id = i,
                    Name = NameOfProduct.ProductNames[random.Next(numberofproduct)],
                    Price = random.Next(200)+10,
                    Amount = random.Next(100)+1
                });
            }
        }

        public List<Product> GetProductAll()
        {
            return ProductList;
        }
    }
}
