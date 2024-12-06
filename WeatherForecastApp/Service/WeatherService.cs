using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecastApp.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace WeatherForecastApp.Service
{
    public class WeatherService
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public WeatherService()
        {
            _apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY") ?? throw new InvalidOperationException("API Key not found.");
            _baseUrl = Environment.GetEnvironmentVariable("WEATHER_API_URL") ?? "https://api.openweathermap.org/data/2.5/weather";
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
}
