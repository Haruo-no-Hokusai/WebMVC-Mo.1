using Microsoft.AspNetCore.Mvc;
using TestDataBase1to1toMany.Service;

namespace TestDataBase1to1toMany.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICservice ct;

        public CategoryController(ICservice _ct) 
        {
            ct = _ct;
        }
        public async Task<IActionResult> Index()
        {
            var CategoryModel = ct.GetAllCategory();
            return View(CategoryModel);
        }
        public async Task<IActionResult> Add() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            if (!ModelState.IsValid) return View();

            await ct.AddCategory(category);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var category = await ct.GetCategory(id);

            if (category == null)
            {
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid) return View();

            await ct.UbdateCategory(category);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var category = await ct.GetCategory(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }

            else
            {
                await ct.DeleteCategory(category);
            }
            return RedirectToAction("Index");
        }
    }
}
