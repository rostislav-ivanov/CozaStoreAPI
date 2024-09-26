using CozaStoreAPI.Core.ModelsDTO;

namespace CozaStoreAPI.Core.Contracts
{
    public interface IOrdersService
    {
        Task<string> CreateOrderAsync(OrderDTO order, Guid userId);
        Task<IEnumerable<OrderGetDTO>> GetOrdersAsync(Guid userId);
    }
}
