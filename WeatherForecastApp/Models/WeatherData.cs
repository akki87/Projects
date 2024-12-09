namespace WeatherForecastApp.Models
{
    public class WeatherData
    {
        public Main Main { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public Weather[] Weather { get; set; }
    }
}
