using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics;

/// <summary>
/// Represents extensions for a <see cref="Counter{T}"/>
/// </summary>
public static class CounterExtensions
{
    public static void AddMs(this Counter<double> counter, TimedResult result)
    {
        counter.Add(result.Time.TotalMilliseconds);
    }

    public static void AddMs(this Counter<double> counter, TimedResult result, TagList tags)
    {
        counter.Add(result.Time.TotalMilliseconds, tags);
    }

    public static void AddMs(this Counter<double> counter, TimedResult result, params KeyValuePair<string, object?>[] tags)
    {
        counter.Add(result.Time.TotalMilliseconds, tags);
    }
}
