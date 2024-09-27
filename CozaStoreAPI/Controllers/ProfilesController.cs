using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozaStoreAPI.Controllers
{
    public class ProfilesController : BaseApiController
    {
        private readonly IProfileService _profileService;
        private readonly ILogger<ProfilesController> _logger;

        public ProfilesController(IProfileService profileService, ILogger<ProfilesController> logger)
        {
            _profileService = profileService;
            _logger = logger;
        }

        // GET: api/profiles
        [HttpGet]
        public async Task<ActionResult<ProfileDTO>> GetProfile()
        {
            try
            {
                Guid userId = User.GetUserId();
                ProfileDTO? profile = await _profileService.GetProfileAsync(userId);

                if (profile is null)
                {
                    return NotFound();
                }

                return Ok(profile);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when retrieving profile");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving profile");
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }

        // PUT: api/profiles
        [HttpPut]
        public async Task<ActionResult<ProfileDTO>> UpdateProfile(ProfileDTO profile)
        {
            try
            {
                Guid userId = User.GetUserId();

                var updatedProfile = await _profileService.UpdateProfileAsync(userId, profile);

                if (updatedProfile is null)
                {
                    return NotFound();
                }

                return Ok(updatedProfile);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when updating profile");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating profile");
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }
    }
}
