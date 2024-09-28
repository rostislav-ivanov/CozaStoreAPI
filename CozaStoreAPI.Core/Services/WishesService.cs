using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Infrastructure.Data;
using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CozaStoreAPI.Core.Services
{
    public class WishesService : IWishesService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<WishesService> _logger;

        public WishesService(ApplicationDbContext context, ILogger<WishesService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<int>> GetWishesAsync(Guid userId)
        {
            try
            {
                var wishes = await _context.Wishes
                    .Where(w => w.AppUserId == userId)
                    .Select(w => w.ProductId)
                    .ToListAsync();

                return wishes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving wishes for user {UserId}.", userId);
                throw;
            }
        }

        public async Task UpdateWishesAsync(Guid userId, IEnumerable<int> wishes)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var user = await _context.Users.FindAsync(userId);
                    if (user == null)
                    {
                        _logger.LogWarning("User with ID {UserId} not found.", userId);
                        throw new ArgumentException("User not found");
                    }

                    var userWishes = await _context.Wishes
                        .Where(w => w.AppUserId == userId)
                        .ToListAsync();

                    var productIds = await _context.Products
                        .Where(p => wishes.Contains(p.Id))
                        .Select(p => p.Id)
                        .ToListAsync();

                    var newWishes = productIds
                        .Select(id => new WishUser
                        {
                            AppUserId = user.Id,
                            ProductId = id
                        });

                    _context.Wishes.RemoveRange(userWishes);
                    await _context.SaveChangesAsync();

                    await _context.Wishes.AddRangeAsync(newWishes);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "An error occurred while updating wishes for user {UserId}.", userId);
                    throw new Exception("An error occurred while updating wishes", ex);
                }
            });


        }
    }
}
