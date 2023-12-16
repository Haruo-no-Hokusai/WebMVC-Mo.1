namespace TestDataBase1to1toMany.Models
{
    public class ComponentToProduct
    {
        public int ComponentId { get; set; }
        public Component Component { get; set; }
        public int ProductsId { get; set; }
        public Products Products { get; set; }
    }
}
