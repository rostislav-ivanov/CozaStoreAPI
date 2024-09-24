using CozaStoreAPI.Core.ModelsDTO;

namespace CozaStoreAPI.Core.Contracts
{
    public interface IContactsService
    {
        Task<MessageDTO> SendMessageAsync(MessageDTO messageDTO);
        Task SubscribeAsync(EmailDTO email);
    }
}
