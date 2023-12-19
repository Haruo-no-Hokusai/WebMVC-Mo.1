using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HashHaveSalt.Areas.Identity.Data;
using HashHaveSalt.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SaltAuthenDbContextConnection") ?? throw new InvalidOperationException("Connection string 'SaltAuthenDbContextConnection' not found.");

builder.Services.AddDbContext<SaltAuthenDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MyUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<SaltAuthenDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

//ตรวจความถูกต้อง
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
//app.UseEndpoints(endpoints => endpoints.MapRazorPages());

app.Run();
