using BakeryShop_Razor.Model;
using Microsoft.EntityFrameworkCore;

namespace BakeryShop_Razor.Data.BakeryDatabase
{
    public static class BakeryDatabase
    {
        public static ModelBuilder Seed (this ModelBuilder modelBuilder)
        {
            Product[] products = {
                new Product {
                Id = 1,
                Name = "Bagel",
                Description = "Bagel Description.",
                ImageName = "Bagel.png"
                },
                 new Product {
                Id = 2,
                Name = "Baguettes",
                Description = "Baguettes Description.",
                ImageName = "Baguettes.png"
                },
                  new Product {
                Id = 3,
                Name = "Biscuits",
                Description = "Biscuits Description.",
                ImageName = "Biscuits.png"
                },
                   new Product {
                Id = 4,
                Name = "Bread",
                Description = "Bread Description.",
                ImageName = "Bread.png"
                },
                   new Product {
                Id = 5,
                Name = "Cake",
                Description = "Cake Description.",
                ImageName = "Cake.png"
                },
                 new Product {
                Id = 6,
                Name = "Cupcake",
                Description = "Cupcake Description.",
                ImageName = "Cupcake.png"
                },
                  new Product {
                Id = 7,
                Name = "Pie",
                Description = "Pie Description.",
                ImageName = "Pie.png"
                },
                   new Product {
                Id = 8,
                Name = "Pretzel",
                Description = "Pretzel Description.",
                ImageName = "Pretzel.png"
                },
                     new Product {
                Id = 9,
                Name = "Sandwich",
                Description = "Sandwich Description.",
                ImageName = "Sandwich.png"
                },
                   new Product {
                Id = 10,
                Name = "Toast",
                Description = "Toast Description.",
                ImageName = "Toast.png"
                }
            };
            modelBuilder.Entity<Product>().HasData(products);
            return modelBuilder;
        }
    }
}
