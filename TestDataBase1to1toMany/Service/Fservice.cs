namespace TestDataBase1to1toMany.Service
{
    public class Fservice:IFservice
    {
        private readonly FileManagementcs fm;
        List<Feature> featureList;

        public Fservice(FileManagementcs Fm)
        {
            fm = Fm;
            featureList = new List<Feature>();
        }
        public async Task AddFeature(Feature feature)
        {
            await fm.Features.AddAsync(feature);
            await fm.SaveChangesAsync();
        }

        public async Task DeleteFeature(Feature feature)
        {
            fm.Features.Remove(feature);
            await fm.SaveChangesAsync();
        }

        public IEnumerable<Feature> GetAllFeature()
        {
            return fm.Features.OrderByDescending(p => p.Id).ToList();
        }

        public async Task<Feature> GetFeature(int id)
        {
            var feature = await fm.Features.FindAsync(id);
            return feature;
        }

        public async Task UbdateFeature(Feature feature)
        {
            fm.Features.Update(feature);
            await fm.SaveChangesAsync();
        }
        public string GetName(int id)
        {
            var name = fm.Features.Find(id);
            return name.Name;
        }
    }
}
