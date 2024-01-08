using Microsoft.AspNetCore.Mvc;

namespace TestDataBase1to1toMany.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IComservice com;

        public ComponentController(IComservice com) 
        {
            this.com = com;
        }
        public IActionResult Index()
        {
            var Component = com.GetAllComponent();
            return View(Component);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Component component)
        {
            if (ModelState.IsValid) return View();

            await com.AddComponent(component);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var component = await com.GetComponent(id);

            if (component == null)
            {
                return RedirectToAction("Index");
            }

            return View(component);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Component component)
        {
            if (ModelState.IsValid) return View();

            await com.UbdateComponent(component);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var component = await com.GetComponent(id);
            if (component == null)
            {
                return RedirectToAction("Index");
            }

            else
            {
                await com.DeleteComponent(component);
            }
            return RedirectToAction("Index");
        }
    }
}
