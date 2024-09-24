using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : BaseController
    {
        private readonly IProfileService _profileService;

        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        // GET: api/profiles
        [HttpGet]
        public async Task<ActionResult<ProfileDTO>> GetProfile()
        {
            Guid userId = User.GetUserId();
            ProfileDTO? profile = await _profileService.GetProfileAsync(userId);

            if (profile is null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/profiles
        [HttpPut]
        public async Task<ActionResult<ProfileDTO>> UpdateProfile([FromBody] ProfileDTO profile)
        {
            Guid userId = User.GetUserId();
            ProfileDTO? updatedProfile = await _profileService.UpdateProfileAsync(userId, profile);

            if (updatedProfile is null)
            {
                return NotFound();
            }

            return Ok(updatedProfile);
        }
    }
}
