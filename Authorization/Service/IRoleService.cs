using Authorization.Models;
using Microsoft.AspNetCore.Identity;

namespace Authorization.Service
{
    public interface IRoleService
    {
        Task<List<IdentityRole>> Get();
        Task<bool> Add(Roledto roledto);
        Task<bool> Update(RoleUpdateDto roleUpdateDto);
        Task<IdentityRole> Find(string name);
        Task<bool> Delete(string name);
    }
}
