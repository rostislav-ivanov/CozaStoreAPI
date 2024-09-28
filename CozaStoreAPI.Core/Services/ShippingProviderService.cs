using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Infrastructure.Data;
using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace CozaStoreAPI.Core.Services
{
    public class ShippingProviderService : IShippingProviderService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ShippingProviderService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ShippingProviderService(
            ApplicationDbContext context,
            ILogger<ShippingProviderService> logger,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task GetEcontOfficesAsync()
        {
            var url = _configuration["Econt:Url"];
            var username = _configuration["Econt:Username"];
            var password = _configuration["Econt:Password"];
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                _logger.LogWarning("Econt credentials are missing");
                return;
            }

            var client = _httpClientFactory.CreateClient();
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

            List<EcontOffice> econtOffices = new();
            List<EcontCity> econtCities = new();

            RequestBody body = new()
            {
                CountryCode = "BGR",
            };

            string jsonData = JsonConvert.SerializeObject(body);
            var postData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(url, postData);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var offices = JsonConvert.DeserializeObject<OfficesClass>(responseData);

                    if (offices?.Offices == null)
                    {
                        _logger.LogWarning("No offices found");
                        return;
                    }

                    foreach (var office in offices.Offices)
                    {
                        EcontOffice econtOffice = new()
                        {
                            Id = int.Parse(office.Id),
                            Name = office.NameEn,
                            CityId = office.Address.City.Id
                        };
                        econtOffices.Add(econtOffice);
                        if (!econtCities.Any(c => c.Id == office.Address.City.Id))
                        {
                            EcontCity econtCity = new()
                            {
                                Id = office.Address.City.Id,
                                Name = office.Address.City.NameEn
                            };
                            econtCities.Add(econtCity);
                        }
                    }
                }
                else
                {
                    _logger.LogError("Error: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while fetching Econt offices");
                return;
            }

            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var oldOffices = await _context.EcontOffices.ToListAsync();
                    _context.EcontOffices.RemoveRange(oldOffices);
                    var oldCities = await _context.EcontCities.ToListAsync();
                    _context.EcontCities.RemoveRange(oldCities);
                    await _context.SaveChangesAsync();

                    await _context.EcontCities.AddRangeAsync(econtCities);
                    await _context.EcontOffices.AddRangeAsync(econtOffices);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "Exception occurred while updating Econt offices and cities");
                }
            });

            _logger.LogInformation("GetEcontOfficesAsync called");
        }

    }

    internal class RequestBody
    {
        public string CountryCode { get; set; } = string.Empty;
    }

    internal class OfficesClass
    {
        public List<Office> Offices { get; set; } = new();

        public class Office
        {
            public string Id { get; set; } = string.Empty;
            public string NameEn { get; set; } = string.Empty;

            public AddressClass Address { get; set; } = new();

            public class AddressClass
            {
                public CityClass City { get; set; } = new();

                public class CityClass
                {
                    public int Id { get; set; }
                    public string NameEn { get; set; } = string.Empty;
                }
            }
        }
    }
}
