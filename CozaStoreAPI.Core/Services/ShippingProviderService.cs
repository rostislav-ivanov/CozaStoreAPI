using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Infrastructure.Data;
using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace CozaStoreAPI.Core.Services
{
    public class ShippingProviderService : IShippingProviderService
    {
        private string url = "http://demo.econt.com/ee/services/Nomenclatures/NomenclaturesService.getOffices.json";
        private string username = "iasp-dev";
        private string password = "1Asp-dev";
        private readonly ApplicationDbContext _context;

        public ShippingProviderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task GetEcontOfficesAsync()
        {
            using (HttpClient client = new())
            {
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

                List<EcontOffice> econtOffices = [];
                List<EcontCity> econtCities = [];

                RequestBody body = new()
                {
                    countryCode = "BGR",
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
                            Console.WriteLine("No offices found");
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
                        Console.WriteLine("Error: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }

                var oldOffices = await _context.EcontOffices.ToListAsync();
                _context.EcontOffices.RemoveRange(oldOffices);
                var oldCities = await _context.EcontCities.ToListAsync();
                _context.EcontCities.RemoveRange(oldCities);
                await _context.SaveChangesAsync();

                await _context.EcontCities.AddRangeAsync(econtCities);
                await _context.EcontOffices.AddRangeAsync(econtOffices);
                await _context.SaveChangesAsync();
            }

            Console.WriteLine("GetEcontOfficesAsync called");
        }
    }

    internal class RequestBody
    {
        public string countryCode { get; set; } = string.Empty;
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


