namespace TestDataBase1to1toMany.Service
{
    public class Comservice:IComservice
    {
        private readonly FileManagementcs fm;
        List<Component> comList;

        public Comservice(FileManagementcs Fm)
        {
            fm = Fm;
            comList = new List<Component>();
        }
        public async Task AddComponent(Component com)
        {
            await fm.Components.AddAsync(com);
            await fm.SaveChangesAsync();
        }

        public async Task DeleteComponent(Component com)
        {
            fm.Components.Remove(com);
            await fm.SaveChangesAsync();
        }

        public IEnumerable<Component> GetAllComponent()
        {
            return fm.Components.OrderByDescending(p => p.Id).ToList();
        }

        public async Task<Component> GetComponent(int id)
        {
            var Pd = await fm.Components.FindAsync(id);
            return Pd;
        }

        public async Task UbdateComponent(Component com)
        {
            fm.Components.Update(com);
            await fm.SaveChangesAsync();
        }
        public string GetName(int id)
        {
            var name = fm.Components.Find(id);
            return name.Name;
        }
    }
}
