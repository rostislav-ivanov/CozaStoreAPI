using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozaStoreAPI.Infrastructure.Data.DataConfiguration
{
    internal class ImageProductsConfiguration : IEntityTypeConfiguration<ImageProduct>
    {
        private readonly IEnumerable<ImageProduct> imageProducts =
        [
            new () {
                Id = 1,
                ImagePath = "/images/product-01.jpg",
                ImageOrder = 1,
                ProductId = 1
                },
            new () {
                Id = 2,
                ImagePath = "/images/product-02.jpg",
                ImageOrder = 2,
                ProductId = 1
                },
            new () {
                Id = 3,
                ImagePath = "/images/product-02.jpg",
                ImageOrder = 1,
                ProductId = 2
                },
            new () {
                Id = 4,
                ImagePath = "/images/product-03.jpg",
                ImageOrder = 1,
                ProductId = 3
                },
            new () {
                Id = 5,
                ImagePath = "/images/product-04.jpg",
                ImageOrder = 1,
                ProductId = 4
                },
            new () {
                Id = 6,
                ImagePath = "/images/product-05.jpg",
                ImageOrder = 1,
                ProductId = 5
                },
            new () {
                Id = 7,
                ImagePath = "/images/product-06.jpg",
                ImageOrder = 1,
                ProductId = 6
                },
            new () {
                Id = 8,
                ImagePath = "/images/product-07.jpg",
                ImageOrder = 1,
                ProductId = 7
                },
            new () {
                Id = 9,
                ImagePath = "/images/product-08.jpg",
                ImageOrder = 1,
                ProductId = 8
                },
            new () {
                Id = 10,
                ImagePath = "/images/product-09.jpg",
                ImageOrder = 1,
                ProductId = 9
                },
            new () {
                Id = 11,
                ImagePath = "/images/product-10.jpg",
                ImageOrder = 1,
                ProductId = 10
                },
            new () {
                Id = 12,
                ImagePath = "/images/product-11.jpg",
                ImageOrder = 1,
                ProductId = 11
                },
            new () {
                Id = 13,
                ImagePath = "/images/product-12.jpg",
                ImageOrder = 1,
                ProductId = 12
                },
            new () {
                Id = 14,
                ImagePath = "/images/product-13.jpg",
                ImageOrder = 1,
                ProductId = 13
                },
            new () {
                Id = 15,
                ImagePath = "/images/product-14.jpg",
                ImageOrder = 1,
                ProductId = 14
                },
            new () {
                Id = 16,
                ImagePath = "/images/product-15.jpg",
                ImageOrder = 1,
                ProductId = 15
                },
            new () {
                Id = 17,
                ImagePath = "/images/product-16.jpg",
                ImageOrder = 1,
                ProductId = 16
                },
        ];

        public void Configure(EntityTypeBuilder<ImageProduct> builder)
        {
            builder.HasData(imageProducts);
        }
    }
}