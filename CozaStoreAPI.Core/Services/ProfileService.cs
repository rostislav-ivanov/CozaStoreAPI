using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using CozaStoreAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CozaStoreAPI.Core.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;

        public ProfileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProfileDTO?> GetProfileAsync(Guid userId)
        {
            var profile = await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => new ProfileDTO
                {
                    Email = u.Email ?? string.Empty,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Phone = u.PhoneNumber ?? string.Empty,
                    ShippingCity = u.ShippingCity,
                    ShippingOffice = u.ShippingOffice
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return profile;
        }

        public async Task<ProfileDTO?> UpdateProfileAsync(Guid userId, ProfileDTO profile)
        {
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }

            user.FirstName = profile.FirstName;
            user.LastName = profile.LastName;
            user.PhoneNumber = profile.Phone;
            user.ShippingCity = profile.ShippingCity;
            user.ShippingOffice = profile.ShippingOffice;

            await _context.SaveChangesAsync();

            return profile;
        }
    }
}
