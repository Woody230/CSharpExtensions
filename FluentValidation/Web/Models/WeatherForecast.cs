namespace Woody230.FluentValidation.Web.Models;

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
    /// The required events.
    /// </summary>
    public IList<Event> RequiredEvents { get; init; }

    /// <summary>
    /// The optional events.
    /// </summary>
    public IList<Event> OptionalEvents { get; init; }

    /// <summary>
    /// The optional event.
    /// </summary>
    public Event OptionalEvent { get; init; }

    /// <summary>
    /// The required event.
    /// </summary>
    public Event RequiredEvent { get; init; }
}