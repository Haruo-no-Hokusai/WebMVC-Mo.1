using Microsoft.AspNetCore.Mvc;

namespace TestDataBase1to1toMany.Controllers
{
    public class ConnectionController : Controller
    {
        private readonly IConnect connect;

        public ConnectionController(IConnect connect)
        {
            this.connect = connect;
        }
        public IActionResult Index()
        {
            var ct = connect.GetAllConnection();
            return View(ct);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ComponentToProduct cp)
        {
            if (ModelState.IsValid) return View();

            await connect.AddConnection(cp);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int productId, int componentId)
        {
            var ct = await connect.GetConnection(productId, componentId);

            if (ct == null)
            {
                return RedirectToAction("Index");
            }
            TempData["Pid"] = productId;
            TempData["Cid"] = componentId;
            return View(ct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ComponentToProduct cp, int productId, int componentId)
        {
            if (ModelState.IsValid) return View();
            var m = productId;
            var n = componentId;
            await connect.UbdateConnection(cp);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int productId, int componentId)
        {
            var cp = await connect.GetConnection(productId, componentId);
            if (cp == null)
            {
                return RedirectToAction("Index");
            }

            else
            {
                await connect.DeleteConnection(cp);
            }
            return RedirectToAction("Index");
        }

    }
}
