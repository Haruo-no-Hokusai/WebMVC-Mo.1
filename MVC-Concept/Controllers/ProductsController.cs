using Microsoft.AspNetCore.Mvc;

namespace MVC_Concept.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = new ProductService();
            products.GenerateProduct(20);
            return View(products.GetProductAll());
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
