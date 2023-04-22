using BindableEnum.Library.Attributes;
using BindableEnum.Library.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BindableEnum.Web.Models
{
    /// <summary>
    /// Represents a weather forecast.
    /// </summary>
    public record WeatherForecast
    {
        /// <summary>
        /// The date.
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// The temperature in degrees celsius.
        /// </summary>

        public int TemperatureC { get; set; }

        /// <summary>
        /// The temperature in degrees fahrenheit.
        /// </summary>

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// The summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// The day of the week.
        /// </summary>
        [Required]
        [BindedEnum]
        public BindableEnum<DayOfWeek> DayOfWeek { get; set; }
    }
}