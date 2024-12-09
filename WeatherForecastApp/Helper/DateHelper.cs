using System;

namespace WeatherForecastApp.Helper
{
    public static class DateHelper
    {
        public static string FormatDate(long unixTimestamp, string format = "dd, MMM, yyyy")
        {
            var dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).ToLocalTime();
            return dateTime.ToString(format);
        }

        public static string FormatDate(DateTime dateTime, string format = "dd, MMM, yyyy")
        {
            return dateTime.ToString(format);
        }

        public static string GetDayOfWeek(long unixTimestamp)
        {
            var dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).ToLocalTime();
            return dateTime.DayOfWeek.ToString();
        }

        public static string FormatTime(long unixTimestamp)
        {
            var dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).ToLocalTime();
            return dateTime.ToString("hh:mm tt");
        }
    }
}
