using ImageManagement.Setting;
using Microsoft.AspNetCore.Mvc;

namespace ImageManagement.Data
{
    public class ProductController : Controller
    {
        private readonly IProductService ps;

        public ProductController(IProductService ps) 
        {
            this.ps = ps;
        }
        public async Task<IActionResult> Index()
        {
            return View(await ps.GetProduct());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product,IFormFile formFile) 
        {
            ModelState.Remove("FormFile");
            if (!ModelState.IsValid)return View();
            await ps.Add(product,formFile);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await ps.FindId(id);
            if(product != null)
            {
                await ps.Delete(product);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await ps.FindId(id); 
            if (product == null)
            {
                return RedirectToAction($"{nameof(Index)}");
            }
          
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product,IFormFile formFile)
        {
            ModelState.Remove("FormFile");
            if (!ModelState.IsValid) return View();
            await ps.Ubdate(product,formFile);
            return RedirectToAction(nameof(Index));
        }
    }
}
