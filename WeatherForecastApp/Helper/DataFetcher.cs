using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastApp.Helper
{
    public class DataFetcher
    {
        public async Task<T> FetchDataAsync<T>(Func<Task<T>> fetchData)
        {
            try
            {
                return await fetchData();
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them
                Console.WriteLine($"Error: {ex.Message}");
                return default;
            }
        }
    }
}
