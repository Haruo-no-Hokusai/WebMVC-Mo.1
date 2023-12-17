using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ImageManagement.Models
{
    public class Product
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [DisplayName("Price")]

        [Required(ErrorMessage = "Enter Price")]
        [Range(1,999,ErrorMessage ="Enter 1 to 999")]
        public double Price { get; set; }
        [DisplayName("Amount")]

        [Required(ErrorMessage = "Enter Amount")]
        [Range(1, 500, ErrorMessage = "Enter 1 to 500")]
        public int Amount { get; set; }

        [DisplayName("Picture")]
        public string? ImgUrl { get; set; }
    }
}
