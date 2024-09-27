using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozaStoreAPI.Controllers
{
    public class EcontController : BaseApiController
    {
        private readonly IEcontService _econtService;
        private readonly ILogger<EcontController> _logger;

        public EcontController(IEcontService econtService, ILogger<EcontController> logger)
        {
            _econtService = econtService;
            _logger = logger;
        }

        // GET: api/econt/cities
        [HttpGet("cities")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetCities()
        {
            try
            {
                var cities = await _econtService.GeCitiesAsync();

                return Ok(cities);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when retrieving cities");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving cities");
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }

        // GET: api/econt/offices/5
        [HttpGet("offices/{cityId}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<OfficeDTO>>> GetOffices(int cityId)
        {
            try
            {
                var offices = await _econtService.GetOfficesAsync(cityId);

                return Ok(offices);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when retrieving offices for city {CityId}", cityId);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving offices for city {CityId}", cityId);
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }
    }
}
