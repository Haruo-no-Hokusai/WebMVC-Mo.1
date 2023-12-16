namespace TestDataBase1to1toMany.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Create {  get; set; } = DateTime.UtcNow;
        public int ProductsId { get; set; }
        public Products Products { get; set; }
    }
}
