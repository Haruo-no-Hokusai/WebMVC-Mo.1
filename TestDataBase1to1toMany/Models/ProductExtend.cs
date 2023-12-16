using Microsoft.EntityFrameworkCore;

namespace TestDataBase1to1toMany.Models
{
    [Owned]
    public class ProductExtend
    {
        public string Color { get; set; }
        public string Weight { get; set; }  
    }
}
