using Microsoft.EntityFrameworkCore;

namespace SportsStore_MVC.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A boat For one person",
                        Category ="watersports",
                        Price= 275
                    }, new Product
                    {
                        Name = "LifeJacket",
                        Description = "Protective and fashinoable",
                        Category = "watersports",
                        Price = 45.45m
                    }, new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = "soccer",
                        Price = 19.50m
                    }, new Product
                    {
                        Name = "corner flag",
                        Description = "Give your playing field a professional touch",
                        Category = "soccer",
                        Price = 34.90m
                    }, new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Soccer",
                        Price = 79500
                    }, new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Give your opponent a disadvantage",
                        Category = "Chess",
                        Price = 50.22m
                    });
                context.SaveChanges();
            }
        }
    }
}
