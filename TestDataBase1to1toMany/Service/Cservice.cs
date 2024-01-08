
using Microsoft.EntityFrameworkCore;

namespace TestDataBase1to1toMany.Service
{
    public class Cservice : ICservice
    {
        private readonly FileManagementcs fm;
        List<Category> categoryList;

        public Cservice(FileManagementcs Fm)
        {
            fm = Fm;
            categoryList = new List<Category>();
        }
        public async Task AddCategory(Category category)
        {
            await fm.Categories.AddAsync(category);
            await fm.SaveChangesAsync();
        }

        public async Task DeleteCategory(Category category)
        {
            fm.Categories.Remove(category);
            await fm.SaveChangesAsync();
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return fm.Categories.OrderByDescending(p => p.Id).ToList();                   
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await fm.Categories.FindAsync(id);
            return category;
        }

        public async Task UbdateCategory(Category category)
        {
            fm.Categories.Update(category);
            await fm.SaveChangesAsync();
        }

        public string GetName(int id)
        {
            var name = fm.Categories.Find(id);
            return name.Name;
        }
    }
}
