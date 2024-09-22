using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozaStoreAPI.Infrastructure.Data.DataConfiguration
{
    internal class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        private readonly IEnumerable<Color> colors =
        [
            new () { Id = 1, Name = "White" },
            new () { Id = 2, Name = "Black" },
            new () { Id = 3, Name = "Red" },
            new () { Id = 4, Name = "Green" },
            new () { Id = 5, Name = "Blue" },
        ];

        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasData(colors);
        }
    }
}