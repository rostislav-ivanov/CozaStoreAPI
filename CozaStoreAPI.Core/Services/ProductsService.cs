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
                    Image = p.Images.Select(im => im.ImagePath).FirstOrDefault() ?? string.Empty
                })
                .Skip(offset)
                .Take(size)
                .AsNoTracking()
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsUserAsync(Guid userId)
        {
            var products = await _context.Wishes
                .Where(w => w.AppUserId == userId)
                .Select(w => new ProductDTO
                {
                    Id = w.ProductId,
                    Name = w.Product.Name,
                    Price = w.Product.Price,
                    Image = w.Product.Images
                        .OrderBy(im => im.ImageOrder)
                        .Select(im => im.ImagePath)
                        .FirstOrDefault() ?? string.Empty
                })
                .AsNoTracking()
                .ToListAsync();

            return products;
        }

        public Task<QuickProductDTO?> GetQuickProductAsync(int id)
        {
            var product = _context.Products
                .Where(p => p.Id == id)
                .Select(p => new QuickProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Images = p.Images.Select(im => im.ImagePath),
                    Sizes = p.Sizes.Select(s => s.Size.Name),
                    Colors = p.Colors.Select(c => c.Color.Name),
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return product;
        }


        public Task<ProductDetailsDTO?> GetProductDetailsAsync(int id)
        {
            var product = _context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Images = p.Images.Select(im => im.ImagePath),
                    Price = p.Price,
                    Sizes = p.Sizes.Select(s => s.Size.Name),
                    Colors = p.Colors.Select(c => c.Color.Name),
                    Description = p.Description,
                    Material = p.Material
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return product;
        }

    }
}
