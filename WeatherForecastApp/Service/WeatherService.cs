using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Service
{
    public class WeatherService
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public WeatherService()
        {
            var settings = ConfigureService.GetSettings<Settings>("WeatherForecastApp.settings.json");
            if (settings != null)
            {
                _apiKey = settings.WeatherApiKey;
                _baseUrl = settings.WeatherApiUrl;
            }
        }

        public async Task<WeatherResponse> GetWeatherAsync(double latitude, double longitude)
        {
            string url = $"{_baseUrl}?lat={latitude}&lon={longitude}&appid={_apiKey}&units=metric";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch weather data: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherResponse>(json);
        }
    }
    public class Settings
    {
        public string WeatherApiKey { get; set; }
        public string WeatherApiUrl { get; set; }
    }

}
