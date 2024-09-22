using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozaStoreAPI.Infrastructure.Data.DataConfiguration
{
    internal class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        private readonly IEnumerable<Category> categories =
        [
            new () { Id = 1, Name = "women" },
            new () { Id = 2, Name = "man" },
            new () { Id = 3, Name = "shoes" },
            new () { Id = 4, Name = "watches" },
            new () { Id = 5, Name = "bag" },
        ];

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(categories);
        }
    }
}