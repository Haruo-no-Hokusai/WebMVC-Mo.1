namespace TestDataBase1to1toMany.Service
{
    public class Dservice:IDservice
    {
        private readonly FileManagementcs fm;
        List<Feature> detailList;

        public Dservice(FileManagementcs Fm)
        {
            fm = Fm;
            detailList = new List<Feature>();
        }
        public async Task AddDetail(ProductDetail pd)
        {
            await fm.ProductDetail.AddAsync(pd);
            await fm.SaveChangesAsync();
        }

        public async Task DeleteDetail(ProductDetail pd)
        {
            fm.ProductDetail.Remove(pd);
            await fm.SaveChangesAsync();
        }

        public IEnumerable<ProductDetail> GetAllDetail()
        {
            return fm.ProductDetail.OrderByDescending(p => p.Id).ToList();
        }

        public async Task<ProductDetail> GetDetail(int id)
        {
            var Pd = await fm.ProductDetail.FindAsync(id);
            return Pd;
        }

        public async Task UbdateDetail(ProductDetail pd)
        {
            fm.ProductDetail.Update(pd);
            await fm.SaveChangesAsync();
        }
    }
}
