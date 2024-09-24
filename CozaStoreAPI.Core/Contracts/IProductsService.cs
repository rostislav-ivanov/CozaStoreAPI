using CozaStoreAPI.Core.ModelsDTO;

namespace CozaStoreAPI.Core.Contracts
{
    public interface IProductsService
    {
        Task<int> GetProductsCountAsync(string? category);

        Task<IEnumerable<ProductDTO>> GetProductsQueryAsync(
            string? category,
            int offset,
            int size);

        Task<IEnumerable<ProductDTO>> GetProductsUserAsync(Guid userId);

        Task<QuickProductDTO?> GetQuickProductAsync(int id);

        Task<ProductDetailsDTO?> GetProductDetailsAsync(int id);
    }
}
