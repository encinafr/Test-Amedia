using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Services
{
    public class WeatherService : IWeatherService
    {
        private HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Get()
        {
            var response = await _httpClient.GetAsync("/weatherforecast");
            return await response.Content.ReadAsStringAsync();
        }

    }
}
