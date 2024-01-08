global using TestDataBase1to1toMany.Models;
global using TestDataBase1to1toMany.Data;
global using TestDataBase1to1toMany.Service;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FileManagementcs>();
builder.Services.AddScoped<ICservice, Cservice>();
builder.Services.AddScoped<IComservice, Comservice>();
builder.Services.AddScoped<IDservice, Dservice>();
builder.Services.AddScoped<IFservice, Fservice>();
builder.Services.AddScoped<IPservice, Pservice>();
builder.Services.AddScoped<IConnect, Connect>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
