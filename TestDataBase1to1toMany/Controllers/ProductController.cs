using Microsoft.AspNetCore.Mvc;
using TestDataBase1to1toMany.Service;

namespace TestDataBase1to1toMany.Controllers
{
    public class ProductController : Controller
    {
        private readonly IPservice ps;

        public ProductController(IPservice ps) 
        {
            this.ps = ps;
        }
        public IActionResult Index()
        {
            var ProductModel = ps.GetAllProduct();
            return View(ProductModel);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Products products)
        {
            if (ModelState.IsValid) return View();

            await ps.AddProduct(products);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var product = await ps.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Products product)
        {
            if (ModelState.IsValid) return View();

            await ps.UbdateProduct(product);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var product = await ps.GetProduct(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            else
            {
                await ps.DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
    }
}

