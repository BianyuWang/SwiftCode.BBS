using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API
{/// <summary>
/// weather forecase
/// </summary>
    public class WeatherForecast
    {/// <summary>
    /// date
    /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// temprature in celsius
        /// </summary>
        public int TemperatureC { get; set; }
        /// <summary>
        /// temperature in fahrenheit
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        /// <summary>
        /// summary
        /// </summary>
        public string Summary { get; set; }
    }
}
