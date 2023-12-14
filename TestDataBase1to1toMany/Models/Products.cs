using System.ComponentModel.DataAnnotations.Schema;

namespace TestDataBase1to1toMany.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public int CatagoryId { get; set; }
        //[ForeignKey("TestId")]
        public Category Category { get; set; }
    }
}
