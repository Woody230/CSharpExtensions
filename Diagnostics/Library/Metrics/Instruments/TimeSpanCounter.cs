using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics.Instruments;

/// <summary>
/// Represents a counter for measuring the total time elapsed specified by a <see cref="TimeSpan"/> for a <see cref="TimeInterval"/>.
/// </summary>
public sealed class TimeSpanCounter : Instrument<double>
{
    private readonly TimeInterval _interval;

    internal TimeSpanCounter(Meter meter, InstrumentOptions options, TimeInterval interval) : base(meter, options.Name, options.Unit, options.Description)
    {
        _interval = interval;
        Publish();
    }

    public void Add(TimeSpan time)
    {
        var elapsed = GetElapsed(time);
        RecordMeasurement(elapsed);
    }

    public void Add(TimeSpan time, in TagList tags)
    {
        var elapsed = GetElapsed(time);
        RecordMeasurement(elapsed, tags);
    }

    private double GetElapsed(TimeSpan time) => _interval switch
    {
        TimeInterval.Days => time.TotalDays,
        TimeInterval.Hours => time.TotalHours,
        TimeInterval.Minutes => time.TotalMinutes,
        TimeInterval.Seconds => time.TotalSeconds,
        TimeInterval.Milliseconds => time.TotalMilliseconds,
#if NET8_0_OR_GREATER
        TimeInterval.Microseconds => time.TotalMicroseconds,
        TimeInterval.Nanoseconds => time.TotalNanoseconds,
#endif
        _ => 0
    };
}

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