using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using CozaStoreAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CozaStoreAPI.Core.Services
{
    public class EcontService : IEcontService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EcontService> _logger;

        public EcontService(ApplicationDbContext context, ILogger<EcontService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<CityDTO>> GetCitiesAsync()
        {
            try
            {
                var cities = await _context.EcontCities
                    .Select(c => new CityDTO
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .AsNoTracking()
                    .ToListAsync();

                return cities;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving cities.");
                throw;
            }
        }

        public async Task<IEnumerable<OfficeDTO>> GetOfficesAsync(int cityId)
        {
            try
            {
                var offices = await _context.EcontOffices
                    .Where(o => o.CityId == cityId)
                    .Select(o => new OfficeDTO
                    {
                        Id = o.Id,
                        Name = o.Name
                    })
                    .AsNoTracking()
                    .ToListAsync();

                return offices;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving offices for cityId {CityId}.", cityId);
                throw;
            }
        }
    }
}
