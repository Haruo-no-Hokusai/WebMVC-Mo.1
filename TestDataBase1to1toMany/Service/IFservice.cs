namespace TestDataBase1to1toMany.Service
{
    public interface IFservice
    {
        IEnumerable<Feature> GetAllFeature();
        Task<Feature> GetFeature(int id);
        Task AddFeature(Feature feature);
        Task DeleteFeature(Feature feature);
        Task UbdateFeature(Feature feature);
        public string GetName(int id);
    }
}
