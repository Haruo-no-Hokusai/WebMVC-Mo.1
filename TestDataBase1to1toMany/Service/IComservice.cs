namespace TestDataBase1to1toMany.Service
{
    public interface IComservice
    {
        IEnumerable<Component> GetAllComponent();
        Task<Component> GetComponent(int id);
        Task AddComponent(Component component);
        Task DeleteComponent(Component component);
        Task UbdateComponent(Component component);
        public string GetName(int id);
    }
}
