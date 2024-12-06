using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;



namespace WeatherForecastApp.Service
{
    public class GetLocationService
    {
        private const string LocationApiUrl = "http://ip-api.com/json/";
        private readonly HttpClient _httpClient;

        public GetLocationService(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        /// <summary>
        /// Retrieves the device's geographic location based on its IP address.
        /// </summary>
        /// <returns>Tuple containing latitude and longitude.</returns>
        public async Task<(double Latitude, double Longitude)> GetDeviceLocationAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync(LocationApiUrl);
                var locationData = JObject.Parse(response);

                double latitude = locationData["lat"]?.ToObject<double>() ?? throw new Exception("Latitude not found in response.");
                double longitude = locationData["lon"]?.ToObject<double>() ?? throw new Exception("Longitude not found in response.");

                return (latitude, longitude);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching device location: {ex.Message}");
            }
            return (0, 0);
        }
    }
}
