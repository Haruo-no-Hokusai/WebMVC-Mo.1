namespace TestDataBase1to1toMany.Service
{
    public interface ICservice
    {
        IEnumerable<Category> GetAllCategory();
        Task<Category> GetCategory(int id);
        Task AddCategory(Category category);
        Task DeleteCategory(Category category);
        Task UbdateCategory(Category category);
        public string GetName (int id);
    }
}
