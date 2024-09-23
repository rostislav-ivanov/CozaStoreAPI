namespace CozaStoreAPI.Core.Contracts
{
    public interface IWishesService
    {
        Task<IEnumerable<int>> GetWishesAsync(Guid userId);
        Task UpdateWishesAsync(Guid userId, IEnumerable<int> wishes);
    }
}
