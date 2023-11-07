namespace Woody230.Monad.Result;

/// <summary>
/// Represents a result that is unsuccessful.
/// </summary>
public interface IFailureResult : IResult
{
    bool IResult.IsSuccess => false;
}

/// <summary>
/// Represents a result that is unsuccessful.
/// </summary>
/// <typeparam name="TFailure">The type of failure.</typeparam>
public interface IFailureResult<TFailure> : IFailureResult
{
    /// <summary>
    /// The failure state.
    /// </summary>
    public TFailure Failure { get; }
}