using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics;

/// <summary>
/// Represents extensions for a <see cref="Counter{T}"/>
/// </summary>
public static class CounterExtensions
{
    public static void AddDays(this Counter<double> counter, TimedResult result)
    {
        counter.Add(result.Time.TotalDays);
    }

    public static void AddDays(this Counter<double> counter, TimedResult result, TagList tags)
    {
        counter.Add(result.Time.TotalDays, tags);
    }

    public static void AddDays(this Counter<double> counter, TimedResult result, params KeyValuePair<string, object?>[] tags)
    {
        counter.Add(result.Time.TotalDays, tags);
    }

    public static void AddHours(this Counter<double> counter, TimedResult result)
    {
        counter.Add(result.Time.TotalHours);
    }

    public static void AddHours(this Counter<double> counter, TimedResult result, TagList tags)
    {
        counter.Add(result.Time.TotalHours, tags);
    }

    public static void AddHours(this Counter<double> counter, TimedResult result, params KeyValuePair<string, object?>[] tags)
    {
        counter.Add(result.Time.TotalHours, tags);
    }

    public static void AddMinutes(this Counter<double> counter, TimedResult result)
    {
        counter.Add(result.Time.TotalMinutes);
    }

    public static void AddMinutes(this Counter<double> counter, TimedResult result, TagList tags)
    {
        counter.Add(result.Time.TotalMinutes, tags);
    }

    public static void AddMinutes(this Counter<double> counter, TimedResult result, params KeyValuePair<string, object?>[] tags)
    {
        counter.Add(result.Time.TotalMinutes, tags);
    }

    public static void AddSeconds(this Counter<double> counter, TimedResult result)
    {
        counter.Add(result.Time.TotalSeconds);
    }

    public static void AddSeconds(this Counter<double> counter, TimedResult result, TagList tags)
    {
        counter.Add(result.Time.TotalSeconds, tags);
    }

    public static void AddSeconds(this Counter<double> counter, TimedResult result, params KeyValuePair<string, object?>[] tags)
    {
        counter.Add(result.Time.TotalSeconds, tags);
    }

    public static void AddMilliseconds(this Counter<double> counter, TimedResult result)
    {
        counter.Add(result.Time.TotalMilliseconds);
    }

    public static void AddMilliseconds(this Counter<double> counter, TimedResult result, TagList tags)
    {
        counter.Add(result.Time.TotalMilliseconds, tags);
    }

    public static void AddMilliseconds(this Counter<double> counter, TimedResult result, params KeyValuePair<string, object?>[] tags)
    {
        counter.Add(result.Time.TotalMilliseconds, tags);
    }

#if NET8_0_OR_GREATER
    public static void AddMicroseconds(this Counter<double> counter, TimedResult result)
    {
        counter.Add(result.Time.TotalMicroseconds);
    }

    public static void AddMicroseconds(this Counter<double> counter, TimedResult result, TagList tags)
    {
        counter.Add(result.Time.TotalMicroseconds, tags);
    }

    public static void AddMicroseconds(this Counter<double> counter, TimedResult result, params KeyValuePair<string, object?>[] tags)
    {
        counter.Add(result.Time.TotalMicroseconds, tags);
    }

    public static void AddNanoseconds(this Counter<double> counter, TimedResult result)
    {
        counter.Add(result.Time.TotalNanoseconds);
    }

    public static void AddNanoseconds(this Counter<double> counter, TimedResult result, TagList tags)
    {
        counter.Add(result.Time.TotalNanoseconds, tags);
    }

    public static void AddNanoseconds(this Counter<double> counter, TimedResult result, params KeyValuePair<string, object?>[] tags)
    {
        counter.Add(result.Time.TotalNanoseconds, tags);
    }
#endif

    public static void Add(this Counter<int> counter)
    {
        counter.Add(1);
    }

    public static void Add(this Counter<int> counter, TagList tags)
    {
        counter.Add(1, tags);
    }

    public static void Add(this Counter<int> counter, params KeyValuePair<string, object?>[] tags)
    {
        counter.Add(1, tags);
    }

    public static void Add(this Counter<long> counter)
    {
        counter.Add(1);
    }

    public static void Add(this Counter<long> counter, TagList tags)
    {
        counter.Add(1, tags);
    }

    public static void Add(this Counter<long> counter, params KeyValuePair<string, object?>[] tags)
    {
        counter.Add(1, tags);
    }
}
