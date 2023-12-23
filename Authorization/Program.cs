global using Authorization.Areas.Identity.Data;
global using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Authorization.Data;
using Authorization.Service;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthorizationContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthorizationContextConnection' not found.");

builder.Services.AddDbContext<AuthorizationContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AuthorizationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<AuthorizationContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRoleService, RoleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
