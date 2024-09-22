using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozaStoreAPI.Infrastructure.Data.DataConfiguration
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        private readonly IEnumerable<AppUser> users = new List<AppUser>()
        {
            new AppUser
            {
                Id = Guid.NewGuid(),
                UserName = "test@test.com",
                NormalizedUserName = "TEST@TEST.COM",
                Email = "test@test.com",
                NormalizedEmail ="TEST@TEST.COM",
                EmailConfirmed = true,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
            },
        };


        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            var hasher = new PasswordHasher<AppUser>();

            users.First().PasswordHash = hasher.HashPassword(users.First(), "Test1234");

            builder.HasData(users);
        }
    }
}