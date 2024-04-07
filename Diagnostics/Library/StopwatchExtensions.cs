using System.Diagnostics;

namespace Woody230.Diagnostics;

/// <summary>
/// Represents extensions for a <see cref="Stopwatch"/>.
/// </summary>
public static class StopwatchExtensions
{
    /// <summary>
    /// Measures the time that the <paramref name="action"/> takes to execute.
    /// </summary>
    public static TimedResult Measure(this Stopwatch stopwatch, Action action)
    {
        stopwatch.Restart();
        action();
        stopwatch.Stop();

        return new(stopwatch.Elapsed);
    }

    /// <summary>
    /// Measures the time that the <paramref name="function"/> takes to execute.
    /// </summary>
    public static TimedResult<T> Measure<T>(this Stopwatch stopwatch, Func<T> function)
    {
        stopwatch.Restart();
        var result = function();
        stopwatch.Stop();

        return new(stopwatch.Elapsed, result);
    }
}
