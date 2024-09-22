using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using CozaStoreAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CozaStoreAPI.Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;

        public ProductsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetProductsCountAsync(string? category)
        {
            var count = await _context.Products
                .Where(p => category == null || p.Category.Name == category)
                .CountAsync();

            return count;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsQueryAsync(string? category, int offset, int size)
        {
            var products = await _context.Products
                .Where(p => category == null || p.Category.Name == category)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Images = p.Images.Select(im => im.ImagePath).ToList()
                })
                .Skip(offset)
                .Take(size)
                .AsNoTracking()
                .ToListAsync();

            return products;
        }
    }
}
