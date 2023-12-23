using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Service
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AuthorizationUser> _userManager;
        public RoleService(RoleManager<IdentityRole> rolemanager,UserManager<AuthorizationUser> userManager) 
        {
            _roleManager = rolemanager;
            _userManager = userManager;
        }
        public async Task<List<IdentityRole>> Get()
        {
            return await _roleManager.Roles.ToListAsync();
        }
    }
}
