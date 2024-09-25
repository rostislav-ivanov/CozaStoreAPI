using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using CozaStoreAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CozaStoreAPI.Core.Services
{
    public class EcontService : IEcontService
    {
        private readonly ApplicationDbContext _context;

        public EcontService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CityDTO>> GeCitiesAsync()
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

        public async Task<IEnumerable<OfficeDTO>> GetOfficesAsync(int cityId)
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
    }
}
