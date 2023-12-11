using Microsoft.AspNetCore.Mvc;
using MVC_Depency.Models;

namespace MVC_Depency.Controllers
{
    public class TESTDepemdencyController : Controller
    {
        private readonly ITEST test;
        private readonly ITEST test1;
        public TESTDepemdencyController(ITEST test,ITEST test1)
        {
            this.test = test;
            this.test1 = test1;
        }
        public IActionResult Index()
        {
            return View(test.GenerateData());
        }
        public IActionResult Index1()
        {
            var group = new {Data1 = test.GenerateData(),Data2 = test1.GenerateData()};
            return View(group);
        }
        public IActionResult Index2()
        {
            return View(test.GenerateData());
        }
    }
}
