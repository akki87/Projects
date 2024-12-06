using DotNetEnv;
using System;
using System.IO;
using System.Windows;
using WeatherForecastApp.Properties;
using WeatherForecastApp.Service;

namespace WeatherForecastApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]  // Single Threaded Apartment model for WPF applications
        public static void Main()
        {
            // Application logic for starting up
            var app = new App();
            var mainWindow = new MainWindow();
            app.Run(mainWindow);
        }
    }
}
