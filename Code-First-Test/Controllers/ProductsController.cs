using Code_First_Test.Models;
using Code_First_Test.Services;
using Microsoft.AspNetCore.Mvc;

namespace Code_First_Test.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices ps;

        public ProductsController(IProductServices ps)
        {
            this.ps = ps;
        }
        public IActionResult Index()
        {
            var product = ps.GetAll();
            return View(product);
        }

        public IActionResult Add()
        {
            return View();
        }
       
        public IActionResult Delate(int Id)
        {
            var product = ps.GetById(Id);

            if (product == null)
            {
                TempData["OK"] = true;
            }
            else
            {
                ps.Delate(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if(!ModelState.IsValid) 
            {
                return View();
            }
            ps.AddProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var product = ps.GetById(Id);
            if (product == null)
            {
                TempData["OK"] = true;
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product) 
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            ps.UpdateProduct(product);
            return RedirectToAction("Index");
        }

    }
}
