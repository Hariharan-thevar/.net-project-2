using CycleStoreStarter.Models;

namespace CycleStoreStarter.Data;
public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (!db.Categories.Any())
        {
            db.Categories.AddRange(new []
            {
                new Category { Name = "Mountain", Slug = "mountain"},
                new Category { Name = "Road", Slug = "road"},
                new Category { Name = "Hybrid", Slug = "hybrid"},
                new Category { Name = "Kids", Slug = "kids"}
            });
            db.SaveChanges();
        }

        if (!db.Products.Any())
        {
            db.Products.AddRange(new []
            {
                new Product { Name = "TrailBlazer 100", Slug="trailblazer-100", Description="Reliable mountain bike", Price=199.99m, Stock=10, ImageFiles="bike1.jpg" },
                new Product { Name = "CityCruiser", Slug="citycruiser", Description="Comfortable hybrid bike", Price=149.50m, Stock=15, ImageFiles="bike2.jpg" },
                new Product { Name = "Speedster Road Pro", Slug="speedster-road-pro", Description="Lightweight road bike", Price=349.00m, Stock=5, ImageFiles="bike3.jpg" }
            });
            db.SaveChanges();
        }
    }
}
