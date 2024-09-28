using CozaStoreAPI.Core.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CozaStoreAPI.Core.Services
{
    public class DailyDataRetrievalService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<DailyDataRetrievalService> _logger;
        private readonly IConfiguration _configuration;
        private readonly TimeSpan _interval;

        public DailyDataRetrievalService(
            IServiceScopeFactory serviceScopeFactory,
            ILogger<DailyDataRetrievalService> logger,
            IConfiguration configuration)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
            _configuration = configuration;
            _interval = TimeSpan.FromDays(1); // Default to 24 hours

            var intervalConfig = _configuration.GetValue<int?>("DailyDataRetrievalService:IntervalInHours");
            if (intervalConfig.HasValue)
            {
                _interval = TimeSpan.FromHours(intervalConfig.Value);
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("DailyDataRetrievalService is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var serviceProvider = scope.ServiceProvider;
                        var shippingProviderService = serviceProvider.GetRequiredService<IShippingProviderService>();

                        await shippingProviderService.GetEcontOfficesAsync();
                    }

                    _logger.LogInformation("DailyDataRetrievalService executed successfully.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while executing DailyDataRetrievalService.");
                }

                try
                {
                    await Task.Delay(_interval, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    _logger.LogInformation("DailyDataRetrievalService is stopping.");
                    break;
                }
            }
        }
    }
}
