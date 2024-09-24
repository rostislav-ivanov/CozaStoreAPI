using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : BaseController
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        // POST api/contacts/messages
        [HttpPost("messages")]
        [AllowAnonymous]
        public async Task<ActionResult<MessageDTO>> SendMessage([FromBody] MessageDTO messageDTO)
        {
            try
            {
                var message = await _contactsService.SendMessageAsync(messageDTO);

                return Ok(message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }

        // POST api/contacts/subscribers
        [HttpPost("subscribers")]
        [AllowAnonymous]
        public async Task<ActionResult<MessageDTO>> Subscribe([FromBody] EmailDTO email)
        {
            try
            {
                await _contactsService.SubscribeAsync(email);

                return Ok(new { message = "You have successfully subscribed to our newsletter" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }
    }
}
