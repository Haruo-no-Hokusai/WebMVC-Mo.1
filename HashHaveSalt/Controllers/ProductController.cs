using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HashHaveSalt.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize] //ยืนยันสิทธิ์
        public IActionResult Buy() 
        {
            return View();        
        }
    }
}
