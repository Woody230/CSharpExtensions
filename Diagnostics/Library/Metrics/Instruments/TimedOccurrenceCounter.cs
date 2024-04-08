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

    /// <summary>
    /// Records a single occurrence and the amount of time the <paramref name="action"/> takes to execute.
    /// </summary>
    public void Record(Action action)
    {
        Record(action, 1);
    }

    /// <summary>
    /// Records a single occurrence and the amount of time the <paramref name="action"/> takes to execute, with the given <paramref name="tags"/>.
    /// </summary>
    public void Record(Action action, in TagList tags)
    {
        Record(action, 1, tags);
    }

    /// <summary>
    /// Records a single occurrence and the amount of time the <paramref name="action"/> takes to execute, with the tags from <paramref name="getTags"/>.
    /// </summary>
    public void Record(Action action, Func<TagList> getTags)
    {
        Record(action, 1, getTags);
    }

    /// <summary>
    /// Records the number of <paramref name="occurrences"/> and the amount of time the <paramref name="action"/> takes to execute.
    /// </summary>
    public void Record(Action action, long occurrences)
    {
        var result = new Stopwatch().Measure(action);
        _occurrenceCounter.Add(occurrences);
        _timeCounter.Add(result);
    }

    /// <summary>
    /// Records the number of <paramref name="occurrences"/> and the amount of time the <paramref name="action"/> takes to execute, with the given <paramref name="tags"/>.
    /// </summary>
    public void Record(Action action, long occurrences, in TagList tags)
    {
        var result = new Stopwatch().Measure(action);
        _occurrenceCounter.Add(occurrences, tags);
        _timeCounter.Add(result, tags);
    }

    /// <summary>
    /// Records the number of <paramref name="occurrences"/> and the amount of time the <paramref name="action"/> takes to execute, with the tags from <paramref name="getTags"/>.
    /// </summary>
    public void Record(Action action, long occurrences, Func<TagList> getTags)
    {
        var result = new Stopwatch().Measure(action);
        var tags = getTags();
        _occurrenceCounter.Add(occurrences, tags);
        _timeCounter.Add(result, tags);
    }

    /// <summary>
    /// Records a single occurrence and the amount of time the <paramref name="function"/> takes to execute.
    /// </summary>
    /// <returns>The result of the <paramref name="function"/>.</returns>
    public T Record<T>(Func<T> function)
    {
        return Record(function, 1);
    }

    /// <summary>
    /// Records a single occurrence and the amount of time the <paramref name="function"/> takes to execute, with the given <paramref name="tags"/>.
    /// </summary>
    /// <returns>The result of the <paramref name="function"/>.</returns>
    public T Record<T>(Func<T> function, in TagList tags)
    {
        return Record(function, 1, tags);
    }

    /// <summary>
    /// Records a single occurrence and the amount of time the <paramref name="function"/> takes to execute, with the tags from <paramref name="getTags"/>.
    /// </summary>
    /// <returns>The result of the <paramref name="function"/>.</returns>
    public T Record<T>(Func<T> function, Func<T, TagList> getTags)
    {
        return Record(function, 1, getTags);
    }

    /// <summary>
    /// Records the number of <paramref name="occurrences"/> and the amount of time the <paramref name="function"/> takes to execute.
    /// </summary>
    /// <returns>The result of the <paramref name="function"/>.</returns>
    public T Record<T>(Func<T> function, long occurrences)
    {
        var result = new Stopwatch().Measure(function);
        _occurrenceCounter.Add(occurrences);
        _timeCounter.Add(result);
        return result;
    }

    /// <summary>
    /// Records the number of <paramref name="occurrences"/> and the amount of time the <paramref name="function"/> takes to execute, with the given <paramref name="tags"/>.
    /// </summary>
    /// <returns>The result of the <paramref name="function"/>.</returns>
    public T Record<T>(Func<T> function, long occurrences, in TagList tags)
    {
        var result = new Stopwatch().Measure(function);
        _occurrenceCounter.Add(occurrences, tags);
        _timeCounter.Add(result, tags);
        return result;
    }

    /// <summary>
    /// Records the number of <paramref name="occurrences"/> and the amount of time the <paramref name="function"/> takes to execute, with the tags from <paramref name="getTags"/>.
    /// </summary>
    /// <returns>The result of the <paramref name="function"/>.</returns>
    public T Record<T>(Func<T> function, long occurrences, Func<T, TagList> getTags)
    {
        var result = new Stopwatch().Measure(function);
        var tags = getTags(result);
        _occurrenceCounter.Add(occurrences, tags);
        _timeCounter.Add(result, tags);
        return result;
    }
}