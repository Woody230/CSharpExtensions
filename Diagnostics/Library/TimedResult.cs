namespace Woody230.Diagnostics;

/// <summary>
/// Represents how long a delegate took to execute.
/// </summary>
/// <param name="Time">How long the delegate took to execute.</param>
public record TimedResult(TimeSpan Time)
{
    public static implicit operator TimeSpan(TimedResult result) => result.Time;
}

/// <summary>
/// Represents the result of a delegate and how long it took to execute.
/// </summary>
/// <typeparam name="T">The type of value.</typeparam>
/// <param name="Value">The result of the delegate.</param>
/// <param name="Time">How long the delegate took to execute.</param>
public record TimedResult<T>(TimeSpan Time, T Value) : TimedResult(Time)
{
    public static implicit operator TimeSpan(TimedResult<T> result) => result.Time;
    public static implicit operator T(TimedResult<T> result) => result.Value;
}
