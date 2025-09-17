using OnlineShop.Data.Models;

namespace OnlineShop.Data;

public static class DbInitializer
{
    public static void Initialize(ShopContext context)
    {
        if (!context.Products.Any())
        {
            // Ensure categories exist first
            if (!context.Categories.Any())
            {
                var categories = new[]
                {
                    new Category { Name = "Shoes", Description = "Footwear of all types" },
                    new Category { Name = "Toys", Description = "Children's toys and games" },
                    new Category { Name = "Clothes", Description = "Apparel and accessories" },
                    new Category { Name = "Electronics", Description = "Electronic devices and accessories" },
                    new Category { Name = "Furniture", Description = "Office and home furniture" },
                    new Category { Name = "Cutlery", Description = "Cups, Mugs, Plates" }
                };

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            // Get categories for reference
            var cutleryCategory = context.Categories.First(c => c.Name == "Cutlery");
            var clothesCategory = context.Categories.First(c => c.Name == "Clothes");
            var furnitureCategory = context.Categories.First(c => c.Name == "Furniture");

            var products = new[]
            {
                new Product
                {
                    Name = "Coffee Mug",
                    Price = 12.99M,
                    Description = "A stylish coffee mug",
                    Category = cutleryCategory
                },
                new Product
                {
                    Name = "T-Shirt",
                    Price = 24.99M,
                    Description = "Cotton t-shirt",
                    Category = clothesCategory
                },
                new Product
                {
                    Name = "Notebook",
                    Price = 5.99M,
                    Description = "100-page lined notebook",
                    Category = furnitureCategory
                },
                new Product
                {
                    Name = "Shirt",
                    Price = 8.99M,
                    Description = "Cotton Mens Shirt",
                    Category = furnitureCategory
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        if (!context.Categories.Any())
        {
            var categories = new[]
            {
                new Category { Name = "Shoes", Description = "Footwear of all types" },
                new Category { Name = "Toys", Description = "Children's toys and games" },
                new Category { Name = "Clothes", Description = "Apparel and accessories" },
                new Category { Name = "Electronic", Description = "Electronic devices and accessories" },
                new Category { Name = "Desks", Description = "Office and home furniture" },
                new Category { Name = "Cutlery", Description = "Cups, Mugs, Plates" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }
}