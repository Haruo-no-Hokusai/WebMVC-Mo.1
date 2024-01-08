namespace TestDataBase1to1toMany.Service
{
    public interface IDservice
    {
        IEnumerable<ProductDetail> GetAllDetail();
        Task<ProductDetail> GetDetail(int id);
        Task AddDetail(ProductDetail pd);
        Task DeleteDetail(ProductDetail pd);
        Task UbdateDetail(ProductDetail pd);
    }
}
