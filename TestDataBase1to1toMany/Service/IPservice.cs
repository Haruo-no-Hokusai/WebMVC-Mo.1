namespace TestDataBase1to1toMany.Service
{
    public interface IPservice
    {
        IEnumerable<Products> GetAllProduct();
        Task<Products> GetProduct(int id);
        Task AddProduct(Products products);
        Task DeleteProduct(Products products);
        Task UbdateProduct(Products products);
        public string GetName(int id);
    }
}
