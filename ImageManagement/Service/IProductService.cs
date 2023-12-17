namespace ImageManagement.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProduct();
        Task Add(Product product,IFormFile formFile);
        Task<Product> FindId(int Id);
        Task Delete(Product product);
        Task Ubdate(Product product, IFormFile formFile);
    }
}
