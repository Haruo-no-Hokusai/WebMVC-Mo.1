using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebMVC_Mo._1.Models;
namespace WebMVC_Mo._1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var product = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Coffee",
                    Price = 50,
                    Amount = 100,
                },
                new Product()
                {
                    Id = 2,
                    Name = "Chocolate",
                    Price = 100,
                    Amount = 50,
                },
            };
            return View(new { product,Title = "Coffee Shop"});
        }
    }
}
