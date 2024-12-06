using DotNetEnv;
using System;
using System.Windows;

namespace WeatherForecastApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Env.Load("E:\\Projects\\WeatherForecastApp\\.env");
            string apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");
            string apiUrl = Environment.GetEnvironmentVariable("WEATHER_API_URL");
        }
    }
}
