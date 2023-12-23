using Authorization.Service;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
