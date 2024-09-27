using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozaStoreAPI.Controllers
{
    public class ContactsController : BaseApiController
    {
        private readonly IContactsService _contactsService;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactsService contactsService, ILogger<ContactsController> logger)
        {
            _contactsService = contactsService;
            _logger = logger;
        }

        // POST api/contacts/messages
        [HttpPost("messages")]
        [AllowAnonymous]
        public async Task<ActionResult<MessageDTO>> SendMessage(MessageDTO messageDTO)
        {
            try
            {
                var message = await _contactsService.SendMessageAsync(messageDTO);

                return Ok(message);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when sending message");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending message");
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }

        // POST api/contacts/subscribers
        [HttpPost("subscribers")]
        [AllowAnonymous]
        public async Task<ActionResult<MessageDTO>> Subscribe(EmailDTO email)
        {
            try
            {
                await _contactsService.SubscribeAsync(email);

                return Ok(new { message = "You have successfully subscribed to our newsletter" });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when subscribing");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error subscribing");
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }
    }
}
