using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics;

/// <summary>
/// Represents extensions for a <see cref="Counter{T}"/>
/// </summary>
public static class CounterExtensions
{
    public static void Add(this Counter<int> counter)
    {
        counter.Add(1);
    }

    public static void Add(this Counter<int> counter, in TagList tags)
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

    public static void Add(this Counter<long> counter, in TagList tags)
    {
        counter.Add(1, tags);
    }

    public static void Add(this Counter<long> counter, params KeyValuePair<string, object?>[] tags)
    {
        counter.Add(1, tags);
    }
}
