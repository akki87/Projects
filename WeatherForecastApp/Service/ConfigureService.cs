using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace WeatherForecastApp.Service
{
    public class ConfigureService
    {
        public static T GetSettings<T>(string resource)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "WeatherForecastApp.settings.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}
