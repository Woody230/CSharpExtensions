using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics;

/// <summary>
/// Represents a counter for measuring the total time elapsed specified by a <see cref="TimeSpan"/> for a <see cref="TimeInterval"/>.
/// </summary>
public sealed class TimeSpanCounter : Instrument<double>
{
    private readonly Counter<double> _counter;
    private readonly TimeInterval _interval;

    public TimeSpanCounter(Counter<double> counter, TimeInterval interval) : base(counter.Meter, counter.Name, counter.Unit, counter.Description)
    {
        _counter = counter;
        _interval = interval;
    }

    public void Add(TimeSpan time)
    {
        var elapsed = GetElapsed(time);
        _counter.Add(elapsed);
    }

    public void Add(TimeSpan time, in TagList tags)
    {
        var elapsed = GetElapsed(time);
        _counter.Add(elapsed, tags);
    }

    public void Add(TimeSpan time, params KeyValuePair<string, object?>[] tags)
    {
        var elapsed = GetElapsed(time);
        _counter.Add(elapsed, tags);
    }

    private double GetElapsed(TimeSpan time) => _interval switch
    {
        TimeInterval.Days => time.TotalDays,
        TimeInterval.Hours => time.TotalHours,
        TimeInterval.Minutes => time.TotalMinutes,
        TimeInterval.Seconds => time.TotalSeconds,
        TimeInterval.Milliseconds => time.TotalMilliseconds,
#if NET8_0_OR_GREATER
        TimeInterval.Microsceonds => time.TotalMicroseconds,
        TimeInterval.Nanoseconds => time.TotalNanoseconds,
#endif
        _ => time.TotalMilliseconds
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
    Microsceonds,
    Nanoseconds
#endif
}