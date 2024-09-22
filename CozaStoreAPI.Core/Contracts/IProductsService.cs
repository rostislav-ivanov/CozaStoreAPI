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
    }
}
