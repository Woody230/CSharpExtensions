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

#if NET8_0_OR_GREATER
    Microseconds,
    Nanoseconds
#endif
}
