using System;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Helper
{
    public static class WeatherConditionHelper
    {
        public static string GetWeatherBackgroundImage(WeatherResponse weatherData)
        {
            if (weatherData == null || weatherData.weather == null || weatherData.weather.Count == 0)
                return "Images/default.jpeg"; // Fallback image

            // Determine if it's day or night
            var currentTime = DateTimeOffset.FromUnixTimeSeconds(weatherData.dt).ToLocalTime();
            var sunriseTime = DateTimeOffset.FromUnixTimeSeconds(weatherData.sys.sunrise).ToLocalTime();
            var sunsetTime = DateTimeOffset.FromUnixTimeSeconds(weatherData.sys.sunset).ToLocalTime();
            var isDay = currentTime >= sunriseTime && currentTime < sunsetTime;

            // Select image based on weather condition and time of day
            var timeSuffix = isDay ? "-day" : "-night";

            return weatherData.weather[0].main.ToLower() switch
            {
                "clear" => $"Images/clear{timeSuffix}.jpeg",
                "clouds" => $"Images/cloud{timeSuffix}.jpeg",
                "rain" => $"Images/rain{timeSuffix}.jpeg",
                "snow" => $"Images/snow{timeSuffix}.jpeg",
                "haze"  => $"Images/haze{timeSuffix}.jpeg",
                "mist" => $"Images/snow{timeSuffix}.jpeg",
                "thunderstorm" => $"Images/thunderstorm{timeSuffix}.jpeg",
                _ => $"Images/Weather/default.jpeg", // Fallback image for unknown conditions
            };
        }
    }
}
