using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using CozaStoreAPI.Infrastructure.Data;
using CozaStoreAPI.Infrastructure.Data.Models;

namespace CozaStoreAPI.Core.Services
{
    public class ContactsService : IContactsService
    {
        private readonly ApplicationDbContext _context;

        public ContactsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MessageDTO> SendMessageAsync(MessageDTO messageDTO)
        {

            await _context.Messages.AddAsync(new Message
            {
                Email = messageDTO.Email,
                FirstName = messageDTO.FirstName,
                LastName = messageDTO.LastName,
                Subject = messageDTO.Subject,
                Content = messageDTO.Content
            });

            await _context.SaveChangesAsync();

            return messageDTO;
        }

        public async Task SubscribeAsync(EmailDTO email)
        {
            await _context.Subscribes.AddAsync(new Subscribe { Email = email.Email });

            await _context.SaveChangesAsync();
        }
    }
}
