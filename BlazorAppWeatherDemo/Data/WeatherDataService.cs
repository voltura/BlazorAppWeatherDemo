using Microsoft.Extensions.Caching.Memory;

namespace BlazorAppWeatherDemo.Data
{
    public class WeatherDataService
    {
        private readonly HttpClient _client;
        private static readonly SemaphoreSlim _lock = new(1, 1);
        private static readonly MemoryCacheEntryOptions _cacheOptions2Min = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(2));
        private readonly IMemoryCache _memoryCache;

        public WeatherDataService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _client = new();
        }

        public async Task<WeatherData?> GetWeatherDataAsync(double longitude, double latitude)
        {
            try
            {
                await _lock.WaitAsync();
                var memkey = $"WeatherDataLong{longitude}Lat{latitude}";
                if (_memoryCache.TryGetValue(memkey, out WeatherData? weatherData))
                {
                    return weatherData;
                }
                string url = $"https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/{longitude}/lat/{latitude}/data.json";
                url = url.Replace(',', '.');
                weatherData = await _client.GetFromJsonAsync<WeatherData>(url);
                _memoryCache.Set(memkey, weatherData, _cacheOptions2Min);
                return weatherData;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _lock.Release();
            }
        }
    }
}
