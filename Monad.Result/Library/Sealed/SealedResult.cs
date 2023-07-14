namespace Woody230.Monad.Result.Sealed;

/// <summary>
/// Represents a specific case of an either, where one state represents failure and the other state represents success.
/// Additionally, the failure and success states represent a base state.
/// </summary>
/// <typeparam name="TResult">The type of base state.</typeparam>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public class SealedResult<TResult, TFailure, TSuccess> : Result<TFailure, TSuccess>, ISealedResult<TResult, TFailure, TSuccess>
    where TResult : notnull
    where TFailure : notnull, TResult
    where TSuccess : notnull, TResult
{
    /// <summary>
    /// Converts the <paramref name="result"/> is into a <see cref="SealedResult{TResult, TFailure, TSuccess}"/>.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <returns>The <see cref="SealedResult{TResult, TFailure, TSuccess}"/>.</returns>
    /// <exception cref="InvalidOperationException">If the result is not a <typeparamref name="TFailure"/> or <typeparamref name="TSuccess"/>.</exception>
    public static SealedResult<TResult, TFailure, TSuccess> Of(TResult result)
    {
        if (result is TSuccess success)
        {
            return new(success);
        }
        else if (result is TFailure failure)
        {
            return new(failure);
        }
        else
        {
            var successType = typeof(TSuccess).Name;
            var failureType = typeof(TFailure).Name;
            var actualType = result.GetType().Name;
            throw new InvalidOperationException($"Expected the result to be a {successType} or {failureType} but it is a {actualType}.");
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SealedResult{TResult, TFailure, TSuccess}"/> class.
    /// </summary>
    /// <param name="failure">The failure state.</param>
    public SealedResult(TFailure failure) : base(failure)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SealedResult{TResult, TFailure, TSuccess}"/> class.
    /// </summary>
    /// <param name="success">The success state.</param>
    public SealedResult(TSuccess success) : base(success)
    {
    }
}
