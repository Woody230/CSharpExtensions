namespace Woody230.Monad.Result;

/// <summary>
/// Represents a specific case of an either, where one state represents failure and the other state represents success.
/// Additionally, the failure and success states represent a base state.
/// </summary>
/// <typeparam name="TState">The type of base state.</typeparam>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public class SealedEitherResult<TState, TFailure, TSuccess> : EitherResult<TFailure, TSuccess>, ISealedEitherResult<TState, TFailure, TSuccess>
    where TState : notnull
    where TFailure : notnull, TState
    where TSuccess : notnull, TState
{
    /// <summary>
    /// Converts the <paramref name="state"/> is into a <see cref="SealedEitherResult{TResult, TFailure, TSuccess}"/>.
    /// </summary>
    /// <param name="state">The result.</param>
    /// <returns>The <see cref="SealedEitherResult{TResult, TFailure, TSuccess}"/>.</returns>
    /// <exception cref="InvalidOperationException">If the result is not a <typeparamref name="TFailure"/> or <typeparamref name="TSuccess"/>.</exception>
    public static SealedEitherResult<TState, TFailure, TSuccess> Of(TState state)
    {
        if (state is TSuccess success)
        {
            return new(success);
        }
        else if (state is TFailure failure)
        {
            return new(failure);
        }
        else
        {
            var successType = typeof(TSuccess).Name;
            var failureType = typeof(TFailure).Name;
            var actualType = state.GetType().Name;
            throw new InvalidOperationException($"Expected the result to be a {successType} or {failureType} but it is a {actualType}.");
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SealedEitherResult{TResult, TFailure, TSuccess}"/> class.
    /// </summary>
    /// <param name="failure">The failure state.</param>
    public SealedEitherResult(TFailure failure) : base(failure)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SealedEitherResult{TResult, TFailure, TSuccess}"/> class.
    /// </summary>
    /// <param name="success">The success state.</param>
    public SealedEitherResult(TSuccess success) : base(success)
    {
    }

    public static implicit operator TSuccess(SealedEitherResult<TState, TFailure, TSuccess> result) => result.Success;
    public static implicit operator TFailure(SealedEitherResult<TState, TFailure, TSuccess> result) => result.Failure;
    public static implicit operator TState(SealedEitherResult<TState, TFailure, TSuccess> result) => result.IsSuccess ? result.Success : result.Failure;
    public static implicit operator SealedEitherResult<TState, TFailure, TSuccess>(TSuccess success) => new(success);
    public static implicit operator SealedEitherResult<TState, TFailure, TSuccess>(TFailure failure) => new(failure);
    public static implicit operator SealedEitherResult<TState, TFailure, TSuccess>(TState root) => Of(root);
}
