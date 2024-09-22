using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozaStoreAPI.Infrastructure.Data.DataConfiguration
{
    internal class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        private readonly IEnumerable<Category> categories =
        [
            new () { Id = 1, Name = "Women" },
            new () { Id = 2, Name = "Man" },
            new () { Id = 3, Name = "Shoes" },
            new () { Id = 4, Name = "Watches" },
            new () { Id = 5, Name = "Bag" },
        ];

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(categories);
        }
    }
}