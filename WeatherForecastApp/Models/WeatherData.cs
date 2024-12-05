using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
