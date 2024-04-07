namespace Woody230.Diagnostics;

/// <summary>
/// Represents how long a delegate took to execute.
/// </summary>
/// <param name="Elapsed">How long the delegate took to execute.</param>
public record TimedResult(TimeSpan Elapsed)
{
    public static implicit operator TimeSpan(TimedResult result) => result.Elapsed;
}

/// <summary>
/// Represents the result of a delegate and how long it took to execute.
/// </summary>
/// <typeparam name="T">The type of value.</typeparam>
/// <param name="Elapsed">How long the delegate took to execute.</param>
/// <param name="Value">The result of the delegate.</param>
public record TimedResult<T>(TimeSpan Elapsed, T Value) : TimedResult(Elapsed)
{
    public static implicit operator TimeSpan(TimedResult<T> result) => result.Elapsed;
    public static implicit operator T(TimedResult<T> result) => result.Value;
}
