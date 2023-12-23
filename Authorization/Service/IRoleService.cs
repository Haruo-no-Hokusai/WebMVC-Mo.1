using Microsoft.AspNetCore.Identity;

namespace Authorization.Service
{
    public interface IRoleService
    {
        Task<List<IdentityRole>> Get(); 
    }
}
