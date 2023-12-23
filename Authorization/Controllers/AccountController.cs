using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AuthorizationUser> _userManager;
        public AccountController(UserManager<AuthorizationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            return View(users);
        }
    }
}
