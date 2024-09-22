using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozaStoreAPI.Infrastructure.Data.DataConfiguration
{
    internal class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        private readonly IEnumerable<Size> sizes =
        [
            new () { Id = 1, Name = "XS" },
            new () { Id = 2, Name = "S" },
            new () { Id = 3, Name = "M" },
            new () { Id = 4, Name = "L" },
            new () { Id = 5, Name = "XL" },
            new () { Id = 6, Name = "36" },
            new () { Id = 7, Name = "37" },
            new () { Id = 8, Name = "38" },
            new () { Id = 9, Name = "39" },
            new () { Id = 10, Name = "40" },
            new () { Id = 11, Name = "85" },
            new () { Id = 12, Name = "90" },
            new () { Id = 13, Name = "95" },
            new () { Id = 14, Name = "100" },
        ];

        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasData(sizes);
        }
    }
}