using Microsoft.AspNetCore.Identity;
using AuthenDb.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using AuthenDb.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthenDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthenDbContextConnection' not found.");

builder.Services.AddDbContext<AuthenDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MyDbUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<AuthenDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
