using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics.Instruments;

/// <summary>
/// Represents a counter for measuring the total time elapsed specified by a <see cref="TimeSpan"/> for a <see cref="TimeInterval"/>.
/// </summary>
public sealed class TimeSpanCounter : OptionsInstrument<double>
{
    private readonly Counter<double> _counter;
    private readonly TimeInterval _interval;

    internal TimeSpanCounter(Meter meter, InstrumentOptions options, Counter<double> counter, TimeInterval interval): base(meter, options)
    {
        _counter = counter;
        _interval = interval;
    }

    public new bool Enabled => _counter.Enabled;

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