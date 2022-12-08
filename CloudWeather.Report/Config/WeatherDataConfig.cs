﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudWeather.Report.Config
{
    public class WeatherDataConfig
    {
        public string PrecipDataProtocol { get; set; } = string.Empty;
        public string PrecipDataHost { get; set; } = string.Empty;
        public string PrecipDataPort { get; set; } = string.Empty;
        public string TempDataProtocol { get; set; } = string.Empty;
        public string TempDataHost { get; set; } = string.Empty;
        public string TempDataPort { get; set; } = string.Empty;
    }
}
