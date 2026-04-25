using ValidIpandBlockCountires.Service.Services;
using ValidIPandBlockCountries.Core.Models;

namespace ValidIPandBlockedCountries.API
{
    public class TempBlockedCountriesCleanupService : BackgroundService
    {
        private readonly InMemorystore _store;
        private readonly ILogger<TempBlockedCountriesCleanupService> _logger;

        public TempBlockedCountriesCleanupService(InMemorystore store , ILogger<TempBlockedCountriesCleanupService> logger)
        {
            _store = store;
            _logger = logger;
         
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           _logger.LogInformation("TempBlockedCountriesCleanupService is starting.");
            while (!stoppingToken.IsCancellationRequested)
            {
                try{
                    var expiredBlocks = _store.TempBlockedCountries.Where(country => country.Value <= DateTime.UtcNow).
                      Select(country => country.Key).ToList();
                    foreach (var country in expiredBlocks)
                    {
                        _store.TempBlockedCountries.TryRemove(country, out _);
                        _logger.LogInformation($"Removed expired block for country: {country}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while cleaning temp blocks");
                }

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
        
    }
}
