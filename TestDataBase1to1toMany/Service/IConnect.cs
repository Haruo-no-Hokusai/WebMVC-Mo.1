using System;

namespace TestDataBase1to1toMany.Service
{
    public interface IConnect
    {
        IEnumerable<ComponentToProduct> GetAllConnection();
        Task<ComponentToProduct> GetConnection(int productId, int componentId);
        Task AddConnection(ComponentToProduct connect);
        Task DeleteConnection(ComponentToProduct connect);
        Task UbdateConnection(ComponentToProduct connect);
    }
}
