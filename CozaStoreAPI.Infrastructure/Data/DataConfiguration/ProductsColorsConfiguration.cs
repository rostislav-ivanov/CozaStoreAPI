using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozaStoreAPI.Infrastructure.Data.DataConfiguration
{
    internal class ProductsColorsConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        private readonly IEnumerable<ProductColor> productsColors =
        [
            new () {
                ProductId = 1,
                ColorId = 1
                },
            new () {
                ProductId = 1,
                ColorId = 2
                },
            new () {
                ProductId = 1,
                ColorId = 3
                },
            new () {
                ProductId = 1,
                ColorId = 4
                },
            new () {
                ProductId = 1,
                ColorId = 5
                },

            new () {
                ProductId = 2,
                ColorId = 1
                },
            new () {
                ProductId = 2,
                ColorId = 2
                },
            new () {
                ProductId = 2,
                ColorId = 3
                },
            new () {
                ProductId = 2,
                ColorId = 4
                },
            new () {
                ProductId = 2,
                ColorId = 5
                },
            new () {
                ProductId = 3,
                ColorId = 1
                },
            new () {
                ProductId = 3,
                ColorId = 2
                },
            new () {
                ProductId = 3,
                ColorId = 3
                },
            new () {
                ProductId = 3,
                ColorId = 4
                },
            new () {
                ProductId = 3,
                ColorId = 5
                },
            new () {
                ProductId = 4,
                ColorId = 1
                },
            new () {
                ProductId = 4,
                ColorId = 2
                },
            new () {
                ProductId = 4,
                ColorId = 3
                },
            new () {
                ProductId = 4,
                ColorId = 4
                },
            new () {
                ProductId = 4,
                ColorId = 5
                },
            new () {
                ProductId = 5,
                ColorId = 1
                },
            new () {
                ProductId = 5,
                ColorId = 2
                },
            new () {
                ProductId = 5,
                ColorId = 3
                },
            new () {
                ProductId = 5,
                ColorId = 4
                },
            new () {
                ProductId = 5,
                ColorId = 5
                },
            new () {
                ProductId = 7,
                ColorId = 1
                },
            new () {
                ProductId = 7,
                ColorId = 2
                },
            new () {
                ProductId = 7,
                ColorId = 3
                },
            new () {
                ProductId = 7,
                ColorId = 4
                },
            new () {
                ProductId = 7,
                ColorId = 5
                },
            new () {
                ProductId = 8,
                ColorId = 1
                },
            new () {
                ProductId = 8,
                ColorId = 2
                },
            new () {
                ProductId = 8,
                ColorId = 3
                },
            new () {
                ProductId = 8,
                ColorId = 4
                },
            new () {
                ProductId = 8,
                ColorId = 5
                },
            new () {
                ProductId = 9,
                ColorId = 1
                },
            new () {
                ProductId = 9,
                ColorId = 2
                },
            new () {
                ProductId = 9,
                ColorId = 3
                },
            new () {
                ProductId = 9,
                ColorId = 4
                },
            new () {
                ProductId = 9,
                ColorId = 5
                },
            new () {
                ProductId = 10,
                ColorId = 1
                },
            new () {
                ProductId = 10,
                ColorId = 2
                },
            new () {
                ProductId = 10,
                ColorId = 3
                },
            new () {
                ProductId = 10,
                ColorId = 4
                },
            new () {
                ProductId = 10,
                ColorId = 5
                },
            new () {
                ProductId = 11,
                ColorId = 1
                },
            new () {
                ProductId = 11,
                ColorId = 2
                },
            new () {
                ProductId = 11,
                ColorId = 3
                },
            new () {
                ProductId = 11,
                ColorId = 4
                },
            new () {
                ProductId = 11,
                ColorId = 5
                },
            new () {
                ProductId = 12,
                ColorId = 2
                },
            new () {
                ProductId = 12,
                ColorId = 5
                },
            new () {
                ProductId = 13,
                ColorId = 1
                },
            new () {
                ProductId = 13,
                ColorId = 2
                },
            new () {
                ProductId = 13,
                ColorId = 3
                },
            new () {
                ProductId = 13,
                ColorId = 4
                },
            new () {
                ProductId = 13,
                ColorId = 5
                },
            new () {
                ProductId = 14,
                ColorId = 1
                },
            new () {
                ProductId = 14,
                ColorId = 2
                },
            new () {
                ProductId = 14,
                ColorId = 3
                },
            new () {
                ProductId = 14,
                ColorId = 4
                },
            new () {
                ProductId = 14,
                ColorId = 5
                },
            new () {
                ProductId = 16,
                ColorId = 1
                },
            new () {
                ProductId = 16,
                ColorId = 2
                },
            new () {
                ProductId = 16,
                ColorId = 3
                },
            new () {
                ProductId = 16,
                ColorId = 4
                },
            new () {
                ProductId = 16,
                ColorId = 5
                },
        ];
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.HasData(productsColors);
        }
    }
}