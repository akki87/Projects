﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastApp.Models
{
    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }
    public class Clouds
    {
        public int all { get; set; }
    }
}