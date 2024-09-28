using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using CozaStoreAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CozaStoreAPI.Core.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProfileService> _logger;

        public ProfileService(ApplicationDbContext context, ILogger<ProfileService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ProfileDTO?> GetProfileAsync(Guid userId)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the profile for user {UserId}.", userId);
                throw;
            }
        }

        public async Task<ProfileDTO?> UpdateProfileAsync(Guid userId, ProfileDTO profile)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => u.Id == userId)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    _logger.LogWarning("User with ID {UserId} not found.", userId);
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the profile for user {UserId}.", userId);
                throw;
            }
        }
    }
}
