
using CozaStoreAPI.Core.ModelsDTO;

namespace CozaStoreAPI.Core.Contracts
{
    public interface IEcontService
    {
        Task<IEnumerable<CityDTO>> GetCitiesAsync();
        Task<IEnumerable<OfficeDTO>> GetOfficesAsync(int cityId);
    }
}
