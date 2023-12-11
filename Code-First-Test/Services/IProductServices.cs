using Code_First_Test.Models;

namespace Code_First_Test.Services
{
    public interface IProductServices
    {
        void GenerateProduct(int num);
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Delate(Product product);

    }
}
