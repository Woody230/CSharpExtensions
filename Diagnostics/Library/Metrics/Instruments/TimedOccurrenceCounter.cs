using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics.Instruments;

/// <summary>
/// Represents an instrument that measures the number of times an event occurs and how long each event takes to process.
/// </summary>
public sealed class TimedOccurrenceCounter : Instrument
{
    internal readonly Counter<long> _occurrenceCounter;
    internal readonly TimeSpanCounter _timeCounter;

    internal TimedOccurrenceCounter(Meter meter, InstrumentOptions options, Counter<long> occurrenceCounter, TimeSpanCounter timeCounter)
#if NET6_0
        : base(meter, options.Name, options.Unit, options.Description)
#else
        : base(meter, options.Name, options.Unit, options.Description, options.Tags)
#endif
    {
        _occurrenceCounter = occurrenceCounter;
        _timeCounter = timeCounter;
    }

    public void Record(Action action)
    {
        var result = new Stopwatch().Measure(action);
        _occurrenceCounter.Add();
        _timeCounter.Add(result);
    }

    public void Record(Action action, in TagList tags)
    {
        var result = new Stopwatch().Measure(action);
        _occurrenceCounter.Add(tags);
        _timeCounter.Add(result, tags);
    }

    public void Record(Action action, Func<TagList> getTags)
    {
        var result = new Stopwatch().Measure(action);
        var tags = getTags();
        _occurrenceCounter.Add(tags);
        _timeCounter.Add(result, tags);
    }

    public T Record<T>(Func<T> function)
    {
        var result = new Stopwatch().Measure(function);
        _occurrenceCounter.Add();
        _timeCounter.Add(result);
        return result;
    }

    public T Record<T>(Func<T> function, in TagList tags)
    {
        var result = new Stopwatch().Measure(function);
        _occurrenceCounter.Add(tags);
        _timeCounter.Add(result, tags);
        return result;
    }

    public T Record<T>(Func<T> function, Func<T, TagList> getTags)
    {
        var result = new Stopwatch().Measure(function);
        var tags = getTags(result);
        _occurrenceCounter.Add(tags);
        _timeCounter.Add(result, tags);
        return result;
    }
}