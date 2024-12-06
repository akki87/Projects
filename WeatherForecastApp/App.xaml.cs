using DotNetEnv;
using System;
using System.IO;
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
            string exePath = AppDomain.CurrentDomain.BaseDirectory;
            string envPath = Path.Combine(exePath, ".env");
            if (File.Exists(envPath))
            {
                Env.Load(envPath);
                string apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");
                string apiUrl = Environment.GetEnvironmentVariable("WEATHER_API_URL");
            }
            else
            {
                Env.Load("E:\\Projects\\WeatherForecastApp\\.env");
                string apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");
                string apiUrl = Environment.GetEnvironmentVariable("WEATHER_API_URL");
            }
        }
    }
}
