using Microsoft.AspNetCore.Identity;
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
builder.Services.AddScoped<Cart>(sp=>SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IOrderRepository,EFOrderRepository>();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
options.UseSqlServer(
    builder.Configuration["ConnectionStrings:IdentityConnection"]));
builder.Services.AddIdentity<IdentityUser,IdentityRole>().
    AddEntityFrameworkStores<AppIdentityDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
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
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index"); 
SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulate(app);
app.Run();
