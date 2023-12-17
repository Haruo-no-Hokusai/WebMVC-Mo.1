using Microsoft.AspNetCore.Mvc;

namespace TestDataBase1to1toMany.Controllers
{
    public class ComponentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
