using CozaStoreAPI.Core.ModelsDTO;

namespace CozaStoreAPI.Core.Contracts
{
    public interface IProfileService
    {
        Task<ProfileDTO?> GetProfileAsync(Guid userId);
        Task<ProfileDTO?> UpdateProfileAsync(Guid userId, ProfileDTO profile);
    }
}
