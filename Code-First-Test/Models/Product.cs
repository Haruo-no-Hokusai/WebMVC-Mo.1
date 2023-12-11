using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Code_First_Test.Models
{
    public class Product
    {
        [DisplayName("รหัสสินค้า")]
        public int Id { get; set; }
        [DisplayName("ชื่อสินค้า")]
        [Required(ErrorMessage ="Enter")]
        public string Name { get; set; }
        [DisplayName("ราคาสินค้า")]
        [Required(ErrorMessage = "Enter")]
        [Range(1,100000,ErrorMessage ="1-100000")]
        public double Price { get; set; }
        [DisplayName("จำนวนสินค้า")]
        [Required(ErrorMessage = "Enter")]
        [Range(1, 1000, ErrorMessage = "1-1000")]
        public int Amount { get; set; }
    }
}
