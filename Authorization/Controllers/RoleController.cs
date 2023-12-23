using Authorization.Models;
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
        public async Task<IActionResult> Index()
        {
            var result = await _roleService.Get();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Roledto roledto)
        {
            await _roleService.Add(roledto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(string name)
        {
            var result = await _roleService.Find(name);
            if(result == null) { return RedirectToAction(nameof(Index)); }
            var updateDto = new RoleUpdateDto { Name = result.Name };
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(string name)
        {
            await _roleService.Delete(name);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleUpdateDto roleUpdateDto)
        {
            await _roleService.Update(roleUpdateDto);

            return RedirectToAction(nameof(Index));
        }
        
    }
}
