using Microsoft.AspNetCore.Mvc;

namespace TestDataBase1to1toMany.Controllers
{
    public class DetailController : Controller
    {
        private readonly IDservice pd;

        public DetailController(IDservice pd) 
        {
            this.pd = pd;
        }
        public IActionResult Index()
        {
            var details = pd.GetAllDetail();
            return View(details);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDetail details)
        {
            if (ModelState.IsValid) return View();

            await pd.AddDetail(details);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var detail = await pd.GetDetail(id);

            if (detail == null)
            {
                return RedirectToAction("Index");
            }

            return View(detail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDetail detail)
        {
            if (ModelState.IsValid) return View();

            await pd.UbdateDetail(detail);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var detail = await pd.GetDetail(id);
            if (detail == null)
            {
                return RedirectToAction("Index");
            }

            else
            {
                await pd.DeleteDetail(detail);
            }
            return RedirectToAction("Index");
        }
    }
}
