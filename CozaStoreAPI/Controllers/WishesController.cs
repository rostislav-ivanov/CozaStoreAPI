using CozaStoreAPI.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozaStoreAPI.Controllers
{
    public class WishesController : BaseApiController
    {
        private readonly IWishesService _wishesService;
        private readonly ILogger<WishesController> _logger;

        public WishesController(IWishesService wishesService, ILogger<WishesController> logger)
        {
            _wishesService = wishesService;
            _logger = logger;
        }

        // GET: api/Wishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<int>>> GetWish()
        {
            try
            {
                Guid userId = User.GetUserId();

                var wishes = await _wishesService.GetWishesAsync(userId);

                if (wishes is null)
                {
                    return NotFound();
                }

                return Ok(wishes);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when retrieving wishes");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving wishes");
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }


        // POST api/Wishes
        [HttpPost]
        public async Task<IActionResult> UpdateWishes(IEnumerable<int> wishes)
        {
            if (wishes.Any(w => w <= 0))
            {
                return BadRequest(new { message = "All wishes must be positive integers." });
            }

            if (wishes.Count() != wishes.Distinct().Count())
            {
                return BadRequest(new { message = "Duplicate wishes are not allowed." });
            }

            Guid userId = User.GetUserId();

            try
            {
                await _wishesService.UpdateWishesAsync(userId, wishes);

                _logger.LogInformation("Wishes updated successfully for user {UserId}", userId);
                return Ok(new { message = "Wishes updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating wishes for user {UserId}", userId);
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }
    }
}
