using CozaStoreAPI.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CozaStoreAPI.Core.Services
{
    public class DailyDataRetrievalService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public DailyDataRetrievalService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;
                    var shippingProviderService = serviceProvider.GetRequiredService<IShippingProviderService>();

                    await shippingProviderService.GetEcontOfficesAsync();

                    // Wait for 24 hours before the next execution
                    await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
                }
            }
        }
    }
}
