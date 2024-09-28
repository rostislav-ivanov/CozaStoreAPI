using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using CozaStoreAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CozaStoreAPI.Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductsService> _logger;

        public ProductsService(ApplicationDbContext context, ILogger<ProductsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> GetProductsCountAsync(string? category)
        {
            try
            {
                var count = await _context.Products
                    .Where(p => category == null || p.Category.Name == category)
                    .CountAsync();

                return count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the product count.");
                throw;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsQueryAsync(string? category, int offset, int size)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving products.");
                throw;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsUserAsync(Guid userId)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving products for user {UserId}.", userId);
                throw;
            }
        }

        public async Task<QuickProductDTO?> GetQuickProductAsync(int id)
        {
            try
            {
                var product = await _context.Products
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving quick product details for product {ProductId}.", id);
                throw;
            }
        }

        public async Task<ProductDetailsDTO?> GetProductDetailsAsync(int id)
        {
            try
            {
                var product = await _context.Products
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving product details for product {ProductId}.", id);
                throw;
            }
        }
    }
}
