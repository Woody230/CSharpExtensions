using System.Diagnostics;

namespace Woody230.Diagnostics;

/// <summary>
/// Measures the time delegates take to execute.
/// </summary>
public class TimedDelegate
{
    public static readonly TimedDelegate Default = new();

    private readonly Stopwatch _stopwatch;

    public TimedDelegate(Stopwatch stopwatch)
    {
        _stopwatch = stopwatch;
    }

    public TimedDelegate(): this(new Stopwatch())
    {
    }

    /// <summary>
    /// Measures the time that the <paramref name="action"/> takes to execute.
    /// </summary>
    public TimedResult Measure(Action action)
    {
        _stopwatch.Restart();

        action();

        _stopwatch.Stop();

        return new(_stopwatch.Elapsed);
    }

    /// <summary>
    /// Measures the time that the <paramref name="function"/> takes to execute.
    /// </summary>
    public TimedResult<T> Measure<T>(Func<T> function)
    {
        _stopwatch.Restart();

        var result = function();
        _stopwatch.Stop();

        return new(_stopwatch.Elapsed, result);
    }
}
