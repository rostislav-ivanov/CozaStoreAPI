using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozaStoreAPI.Infrastructure.Data.DataConfiguration
{
    internal class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        private readonly IEnumerable<Product> products =
        [
            new () {
                Id = 1,
                Name = "Esprit Ruffle Shirt",
                Description = "Description of product Esprit Ruffle Shirt",
                Price = 16.64m,
                CategoryId = 1,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 2,
                Name = "Herschel supply",
                Description = "Description of product Herschel supply",
                Price = 35.31m,
                CategoryId = 1,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 3,
                Name = "Only Check Trouser",
                Description = "Description of product Only Check Trouser",
                Price = 25.50m,
                CategoryId = 2,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 4,
                Name = "Classic Trench Coat",
                Description = "Description of product Classic Trench Coat",
                Price = 75.00m,
                CategoryId = 1,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 5,
                Name = "Front Pocket Jumper",
                Description = "Description of product Front Pocket Jumper",
                Price = 34.75m,
                CategoryId = 1,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 6,
                Name = "Vintage Inspired Classic",
                Description = "Description of product Vintage Inspired Classic",
                Price = 93.20m,
                CategoryId = 4,
                Material = "",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 7,
                Name = "Shirt in Stretch Cotton",
                Description = "Description of product Shirt in Stretch Cotton",
                Price = 52.66m,
                CategoryId = 1,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 8,
                Name = "Pieces Metallic Printed",
                Description = "Description of product Pieces Metallic Printed",
                Price = 18.96m,
                CategoryId = 1,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 9,
                Name = "Converse All Star Hi Plimsolls",
                Description = "Description of product Converse All Star Hi Plimsolls",
                Price = 75.00m,
                CategoryId = 3,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 10,
                Name = "Femme T-Shirt In Stripe",
                Description = "Description of product Femme T-Shirt In Stripe",
                Price = 25.85m,
                CategoryId = 1,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 11,
                Name = "Herschel supply",
                Description = "Description of product Herschel supply",
                Price = 63.16m,
                CategoryId = 2,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 12,
                Name = "Herschel supply",
                Description = "Description of product Herschel supply",
                Price = 63.15m,
                CategoryId = 2,
                Material = "100% leather",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 13,
                Name = "T-Shirt with Sleeve",
                Description = "Description of product T-Shirt with Sleeve",
                Price = 18.49m,
                CategoryId = 1,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 14,
                Name = "Pretty Little Thing",
                Description = "Description of product Pretty Little Thing",
                Price = 54.79m,
                CategoryId = 1,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 15,
                Name = "Mini Silver Mesh Watch",
                Description = "Description of product Mini Silver Mesh Watch",
                Price = 86.85m,
                CategoryId = 4,
                Material = "",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                },
            new () {
                Id = 16,
                Name = "Square Neck Back",
                Description = "Description of product Square Neck Back",
                Price = 29.64m,
                CategoryId = 1,
                Material = "60% cotton, 40% polyester",
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
                }
            ];


        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(products);
        }
    }
}
