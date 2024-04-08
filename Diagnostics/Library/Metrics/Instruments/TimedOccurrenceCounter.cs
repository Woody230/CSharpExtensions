using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics.Instruments;

/// <summary>
/// Represents an instrument that measures the number of times an event occurs and how long each event takes to process.
/// </summary>
public sealed class TimedOccurrenceCounter : OptionsInstrument
{
    internal readonly Counter<long> _occurrenceCounter;
    internal readonly TimeSpanCounter _timeCounter;

    internal TimedOccurrenceCounter(Meter meter, InstrumentOptions options, Counter<long> occurrenceCounter, TimeSpanCounter timeCounter): base(meter, options)
    {
        _occurrenceCounter = occurrenceCounter;
        _timeCounter = timeCounter;
    }

    public new bool Enabled => _occurrenceCounter.Enabled || _timeCounter.Enabled;

    public void Record(Action action)
    {
        Record(action, 1);
    }

    public void Record(Action action, in TagList tags)
    {
        Record(action, 1, tags);
    }

    public void Record(Action action, Func<TagList> getTags)
    {
        Record(action, 1, getTags);
    }

    public void Record(Action action, long count)
    {
        var result = new Stopwatch().Measure(action);
        _occurrenceCounter.Add(count);
        _timeCounter.Add(result);
    }

    public void Record(Action action, long count, in TagList tags)
    {
        var result = new Stopwatch().Measure(action);
        _occurrenceCounter.Add(count, tags);
        _timeCounter.Add(result, tags);
    }

    public void Record(Action action, long count, Func<TagList> getTags)
    {
        var result = new Stopwatch().Measure(action);
        var tags = getTags();
        _occurrenceCounter.Add(count, tags);
        _timeCounter.Add(result, tags);
    }

    public T Record<T>(Func<T> function)
    {
        return Record(function, 1);
    }

    public T Record<T>(Func<T> function, in TagList tags)
    {
        return Record(function, 1, tags);
    }

    public T Record<T>(Func<T> function, Func<T, TagList> getTags)
    {
        return Record(function, 1, getTags);
    }

    public T Record<T>(Func<T> function, long count)
    {
        var result = new Stopwatch().Measure(function);
        _occurrenceCounter.Add(count);
        _timeCounter.Add(result);
        return result;
    }

    public T Record<T>(Func<T> function, long count, in TagList tags)
    {
        var result = new Stopwatch().Measure(function);
        _occurrenceCounter.Add(count, tags);
        _timeCounter.Add(result, tags);
        return result;
    }

    public T Record<T>(Func<T> function, long count, Func<T, TagList> getTags)
    {
        var result = new Stopwatch().Measure(function);
        var tags = getTags(result);
        _occurrenceCounter.Add(count, tags);
        _timeCounter.Add(result, tags);
        return result;
    }
}