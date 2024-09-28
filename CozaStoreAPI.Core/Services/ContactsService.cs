using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using CozaStoreAPI.Infrastructure.Data;
using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.Extensions.Logging;

namespace CozaStoreAPI.Core.Services
{
    public class ContactsService : IContactsService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ContactsService> _logger;

        public ContactsService(ApplicationDbContext context, ILogger<ContactsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<MessageDTO> SendMessageAsync(MessageDTO messageDTO)
        {
            try
            {
                var message = new Message
                {
                    Email = messageDTO.Email,
                    FirstName = messageDTO.FirstName,
                    LastName = messageDTO.LastName,
                    Subject = messageDTO.Subject,
                    Content = messageDTO.Content
                };

                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();

                return messageDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending message from {Email}", messageDTO.Email);
                throw;
            }
        }

        public async Task SubscribeAsync(EmailDTO email)
        {
            try
            {
                var subscribe = new Subscribe { Email = email.Email };
                await _context.Subscribes.AddAsync(subscribe);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error subscribing email {Email}", email.Email);
                throw;
            }
        }
    }
}
