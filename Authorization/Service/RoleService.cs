using Authorization.Models;
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

        public async Task<bool> Add(Roledto roledto)
        {
            var role = new IdentityRole
            {
                Name = roledto.Name,
                NormalizedName = _roleManager.NormalizeKey(roledto.Name),
            };
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded) { return false; }
            return true;
        }

        public async Task<bool> Delete(string name)
        {
            var role = await Find(name);
            if (role ==  null) { return false; }  

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded) { return false; }
            return true;
        }

        public async Task<IdentityRole> Find(string name)
        {
            return await _roleManager.FindByNameAsync(name);
        }

        public async Task<List<IdentityRole>> Get()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<bool> Update(RoleUpdateDto roleUpdateDto)
        {
            var role = await Find(roleUpdateDto.Name);

            if (role == null) { return false; };

            role.Name = roleUpdateDto.UpdateDto;
            role.NormalizedName = _roleManager.NormalizeKey(roleUpdateDto.UpdateDto);

            var results = await _roleManager.UpdateAsync(role);

            if (!results.Succeeded) { return false;}
            return true;
        }
    }
}
