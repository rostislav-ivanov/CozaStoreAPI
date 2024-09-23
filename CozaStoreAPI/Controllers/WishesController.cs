using CozaStoreAPI.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishesController : BaseController
    {
        private readonly IWishesService _wishesService;

        public WishesController(IWishesService wishesService)
        {
            _wishesService = wishesService;
        }

        // GET: api/<WishesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<int>>> Get()
        {
            Guid userId = User.GetUserId();

            var wishes = await _wishesService.GetWishesAsync(userId);

            if (wishes is null)
            {
                return NotFound();
            }

            return Ok(wishes);
        }


        // POST api/<WishesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IEnumerable<int> wishes)
        {
            Guid userId = User.GetUserId();

            try
            {
                await _wishesService.UpdateWishesAsync(userId, wishes);

                return Ok(new { message = "Wishes updated successfully" });
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
