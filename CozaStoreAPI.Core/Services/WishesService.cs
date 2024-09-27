using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Infrastructure.Data;
using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CozaStoreAPI.Core.Services
{
    public class WishesService : IWishesService
    {
        private readonly ApplicationDbContext _context;

        public WishesService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<int>> GetWishesAsync(Guid userId)
        {
            var wishes = await _context.Wishes
                .Where(w => w.AppUserId == userId)
                .Select(w => w.ProductId)
                .ToListAsync();

            return wishes;
        }

        public async Task UpdateWishesAsync(Guid userId, IEnumerable<int> wishes)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
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
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating wishes", ex);
            }
        }

    }
}
