namespace Woody230.Diagnostics.Metrics.Instruments;

/// <summary>
/// The time interval for a <see cref="TimeSpanCounter"/>.
/// </summary>
public enum TimeInterval
{
    Unspecified,
    Days,
    Hours,
    Minutes,
    Seconds,
    Milliseconds,
    Microseconds,
    Nanoseconds
}
