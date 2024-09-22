using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozaStoreAPI.Infrastructure.Data.DataConfiguration
{
    internal class ProductsSizesConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        private readonly IEnumerable<ProductSize> productsSizes =
        [
            new () {
                ProductId = 1,
                SizeId = 1
                },
            new () {
                ProductId = 1,
                SizeId = 2
                },
            new () {
                ProductId = 1,
                SizeId = 3
                },
            new () {
                ProductId = 1,
                SizeId = 4
                },
            new () {
                ProductId = 1,
                SizeId = 5
                },

            new () {
                ProductId = 2,
                SizeId = 1
                },
            new () {
                ProductId = 2,
                SizeId = 2
                },
            new () {
                ProductId = 2,
                SizeId = 3
                },
            new () {
                ProductId = 2,
                SizeId = 4
                },
            new () {
                ProductId = 2,
                SizeId = 5
                },
            new () {
                ProductId = 3,
                SizeId = 1
                },
            new () {
                ProductId = 3,
                SizeId = 2
                },
            new () {
                ProductId = 3,
                SizeId = 3
                },
            new () {
                ProductId = 3,
                SizeId = 4
                },
            new () {
                ProductId = 3,
                SizeId = 5
                },
            new () {
                ProductId = 4,
                SizeId = 1
                },
            new () {
                ProductId = 4,
                SizeId = 2
                },
            new () {
                ProductId = 4,
                SizeId = 3
                },
            new () {
                ProductId = 4,
                SizeId = 4
                },
            new () {
                ProductId = 4,
                SizeId = 5
                },
            new () {
                ProductId = 5,
                SizeId = 1
                },
            new () {
                ProductId = 5,
                SizeId = 2
                },
            new () {
                ProductId = 5,
                SizeId = 3
                },
            new () {
                ProductId = 5,
                SizeId = 4
                },
            new () {
                ProductId = 5,
                SizeId = 5
                },
            new () {
                ProductId = 7,
                SizeId = 1
                },
            new () {
                ProductId = 7,
                SizeId = 2
                },
            new () {
                ProductId = 7,
                SizeId = 3
                },
            new () {
                ProductId = 7,
                SizeId = 4
                },
            new () {
                ProductId = 7,
                SizeId = 5
                },
            new () {
                ProductId = 8,
                SizeId = 1
                },
            new () {
                ProductId = 8,
                SizeId = 2
                },
            new () {
                ProductId = 8,
                SizeId = 3
                },
            new () {
                ProductId = 8,
                SizeId = 4
                },
            new () {
                ProductId = 8,
                SizeId = 5
                },
            new () {
                ProductId = 9,
                SizeId = 6
                },
            new () {
                ProductId = 9,
                SizeId = 7
                },
            new () {
                ProductId = 9,
                SizeId = 8
                },
            new () {
                ProductId = 9,
                SizeId = 9
                },
            new () {
                ProductId = 10,
                SizeId = 1
                },
            new () {
                ProductId = 10,
                SizeId = 2
                },
            new () {
                ProductId = 10,
                SizeId = 3
                },
            new () {
                ProductId = 10,
                SizeId = 4
                },
            new () {
                ProductId = 10,
                SizeId = 5
                },
            new () {
                ProductId = 11,
                SizeId = 1
                },
            new () {
                ProductId = 11,
                SizeId = 2
                },
            new () {
                ProductId = 11,
                SizeId = 3
                },
            new () {
                ProductId = 11,
                SizeId = 4
                },
            new () {
                ProductId = 11,
                SizeId = 5
                },
            new () {
                ProductId = 12,
                SizeId = 11
                },
            new () {
                ProductId = 12,
                SizeId = 12
                },
            new () {
                ProductId = 12,
                SizeId = 13
                },
            new () {
                ProductId = 12,
                SizeId = 14
                },
            new () {
                ProductId = 13,
                SizeId = 1
                },
            new () {
                ProductId = 13,
                SizeId = 2
                },
            new () {
                ProductId = 13,
                SizeId = 3
                },
            new () {
                ProductId = 13,
                SizeId = 4
                },
            new () {
                ProductId = 13,
                SizeId = 5
                },
            new () {
                ProductId = 14,
                SizeId = 1
                },
            new () {
                ProductId = 14,
                SizeId = 2
                },
            new () {
                ProductId = 14,
                SizeId = 3
                },
            new () {
                ProductId = 14,
                SizeId = 4
                },
            new () {
                ProductId = 14,
                SizeId = 5
                },
            new () {
                ProductId = 16,
                SizeId = 1
                },
            new () {
                ProductId = 16,
                SizeId = 2
                },
            new () {
                ProductId = 16,
                SizeId = 3
                },
            new () {
                ProductId = 16,
                SizeId = 4
                },
            new () {
                ProductId = 16,
                SizeId = 5
                }
            ];

        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasData(productsSizes);
        }
    }
}