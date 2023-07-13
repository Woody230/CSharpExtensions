namespace Woody230.Monad.Result;

/// <summary>
/// Represents a specific case of an either, where one state represents failure and the other state represents success.
/// Additionally, the failure and success states represent a base state.
/// </summary>
/// <typeparam name="TResult">The type of base state.</typeparam>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public class SealedResult<TResult, TFailure, TSuccess> : IResult<TFailure, TSuccess>
    where TResult : notnull, SealedResult<TResult, TFailure, TSuccess>
    where TFailure : notnull, TResult
    where TSuccess : notnull, TResult
{
    /// <inheritdoc/>
    public TFailure Failure
    {
        get
        {
            if (this is TFailure failure)
            {
                return failure;
            }
            else if (IsSuccess)
            {
                throw new InvalidOperationException("Expected the result to be a failure but it is a success.");
            }
            else
            {
                throw new InvalidOperationException($"Expected the result to be a failure but it is a {GetType().Name}.");
            }
        }
    }

    /// <inheritdoc/>
    public TSuccess Success
    {
        get
        {
            if (this is TSuccess success)
            {
                return success;
            }
            else if (IsFailure)
            {
                throw new InvalidOperationException("Expected the result to be a success but it is a failure.");
            }
            else
            {
                throw new InvalidOperationException($"Expected the result to be a success but it is a {GetType().Name}.");
            }
        }
    }

    /// <inheritdoc/>
    public bool IsSuccess => this is TSuccess;

    /// <summary>
    /// Whether the result is a failure.
    /// </summary>
    public bool IsFailure => this is TFailure;
}
