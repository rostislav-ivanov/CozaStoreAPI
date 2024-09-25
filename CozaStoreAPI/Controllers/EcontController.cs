using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcontController : BaseController
    {
        private readonly IEcontService _econtService;

        public EcontController(IEcontService econtService)
        {
            _econtService = econtService;
        }

        // GET: api/econt/cities
        [HttpGet("cities")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetCities()
        {
            var cities = await _econtService.GeCitiesAsync();

            if (cities is null)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        // GET: api/econt/offices/5
        [HttpGet("offices/{cityId}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<OfficeDTO>>> GetOffices([FromRoute] int cityId)
        {
            var offices = await _econtService.GetOfficesAsync(cityId);

            if (offices is null)
            {
                return NotFound();
            }

            return Ok(offices);
        }
    }
}
