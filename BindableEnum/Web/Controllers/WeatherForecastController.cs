using Microsoft.AspNetCore.Mvc;
using Woody230.BindableEnum.Models;
using Woody230.BindableEnum.Web.Models;

namespace Woody230.BindableEnum.Web.Controllers;

/// <summary>
/// The weather forecast controller.
/// </summary>
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets one or more weather forecasts.
    /// </summary>
    /// <returns>The weather forecasts.</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            IDayOfWeek = ((DayOfWeek)index).Bindable()
        })
        .ToArray();
    }

    /// <summary>
    /// Creates a weather forecast.
    /// </summary>
    /// <param name="forecast">The weather forecast.</param>
    /// <returns>The weather forecast.</returns>
    [HttpPost(Name = "CreateWeatherForecast")]
    public IActionResult Post([FromBody] WeatherForecast forecast)
    {
        return new OkObjectResult(forecast);
    }
}