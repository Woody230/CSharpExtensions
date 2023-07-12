namespace Woody230.Monad.Result;

/// <summary>
/// Represents a specific case of an either, where one state represents failure and the other state represents success.
/// </summary>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public interface IResult<TFailure, TSuccess>
{
    /// <summary>
    /// The failure state.
    /// </summary>
    public TFailure Failure { get; }

    /// <summary>
    /// The success state.
    /// </summary>
    public TSuccess Success { get; }

    /// <summary>
    /// Whether the result is a success.
    /// </summary>
    public bool IsSuccess { get; }
}
