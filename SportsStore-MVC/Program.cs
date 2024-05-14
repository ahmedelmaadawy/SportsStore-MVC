using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsStore_MVC.Models;
using SportsStore_MVC.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:SportsStoreConnection"]
        );
});
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute("catpage",
    "{category}/Page{productPage:int}",
    new {Controller ="Home",action="Index"}
    );
app.MapControllerRoute("page",
    "Page{productPage:int}",
    new { Controller = "Home", action = "Index" ,productPage= 1}
    );
app.MapControllerRoute("category",
    "{category}",
    new { Controller = "Home", action = "Index" }
    );
app.MapControllerRoute("pagination", "Products/Page{productPage}",
    new {Controller = "Home", action="index",prodctPage = 1});
app.MapDefaultControllerRoute();
app.MapRazorPages();
SeedData.EnsurePopulated(app);
app.Run();
