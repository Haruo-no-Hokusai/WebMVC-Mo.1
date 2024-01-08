
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace TestDataBase1to1toMany.Service
{
    public class Connect : IConnect
    {
        private readonly FileManagementcs fm;

        public Connect(FileManagementcs Fm) 
        {
            fm = Fm;
        }
        public async Task AddConnection(ComponentToProduct connect)
        {
            await fm.ComponentToProduct.AddAsync(connect);
            await fm.SaveChangesAsync();
        }

        public async Task DeleteConnection(ComponentToProduct connect)
        {
            fm.ComponentToProduct.Remove(connect);
            await fm.SaveChangesAsync();
        }

        public IEnumerable<ComponentToProduct> GetAllConnection()
        {
            return fm.ComponentToProduct.OrderByDescending(p => p.ProductsId).ToList();
        }

        public async Task<ComponentToProduct> GetConnection(int productId, int componentId)
        {
            var componentToProduct = await fm.ComponentToProduct.FirstOrDefaultAsync
                (ctp => ctp.ProductsId == productId && ctp.ComponentId == componentId);
            return componentToProduct;
        }

        public async Task UbdateConnection(ComponentToProduct connect)
        {
            fm.ComponentToProduct.Update(connect);
            await fm.SaveChangesAsync();
        }
  
    }
}
