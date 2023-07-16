namespace Woody230.Monad.Result.Sealed;

/// <summary>
/// Represents a specific case of an either, where one state represents failure and the other state represents success.
/// Additionally, the failure and success states represent a base state.
/// </summary>
/// <typeparam name="TState">The type of base state.</typeparam>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public class SealedResult<TState, TFailure, TSuccess> : Result<TFailure, TSuccess>
    where TState : notnull
    where TFailure : notnull, TState
    where TSuccess : notnull, TState
{
    /// <summary>
    /// Converts the <paramref name="state"/> is into a <see cref="SealedResult{TResult, TFailure, TSuccess}"/>.
    /// </summary>
    /// <param name="state">The result.</param>
    /// <returns>The <see cref="SealedResult{TResult, TFailure, TSuccess}"/>.</returns>
    /// <exception cref="InvalidOperationException">If the result is not a <typeparamref name="TFailure"/> or <typeparamref name="TSuccess"/>.</exception>
    public static SealedResult<TState, TFailure, TSuccess> Of(TState state)
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

    /// <summary>
    /// Implicit converts the result to a success state.
    /// </summary>
    /// <param name="result">The result.</param>
    public static implicit operator TSuccess(SealedResult<TState, TFailure, TSuccess> result) => result.Success;

    /// <summary>
    /// Implicitly converts the result to a failure state.
    /// </summary>
    /// <param name="result">The result.</param>
    public static implicit operator TFailure(SealedResult<TState, TFailure, TSuccess> result) => result.Failure;

    /// <summary>
    /// Implicitly converts the result to a root state.
    /// </summary>
    /// <param name="result">The result.</param>
    public static implicit operator TState(SealedResult<TState, TFailure, TSuccess> result) => result.IsSuccess ? result.Success : result.Failure;

    /// <summary>
    /// Implicitly converts the success state to a result.
    /// </summary>
    /// <param name="success">The success state.</param>
    public static implicit operator SealedResult<TState, TFailure, TSuccess>(TSuccess success) => new(success);

    /// <summary>
    /// Implicitly converts the failure state to a result.
    /// </summary>
    /// <param name="failure">The failure state.</param>
    public static implicit operator SealedResult<TState, TFailure, TSuccess>(TFailure failure) => new(failure);

    /// <summary>
    /// Implicitly converts the root state to a result.
    /// </summary>
    /// <param name="root">The root state.</param>
    public static implicit operator SealedResult<TState, TFailure, TSuccess>(TState root) => Of(root);

    /// <summary>
    /// Applies an action on the result.
    /// </summary>
    /// <param name="onResult">The action to perform.</param>
    /// <returns>This result.</returns>
    public SealedResult<TState, TFailure, TSuccess> Apply(Action<TState> onResult)
    {
        if (IsSuccess)
        {
            onResult(Success);
        }
        else
        {
            onResult(Failure);
        }

        return this;
    }

    /// <summary>
    /// Transforms either possible state into a designated value.
    /// </summary>
    /// <typeparam name="TValue">The type of value.</typeparam>
    /// <param name="onResult">The delegate for transforming the result into the value.</param>
    /// <returns>The value.</returns>
    public TValue Fold<TValue>(Func<TState, TValue> onResult)
    {
        return IsSuccess ? onResult(Success) : onResult(Failure);
    }
}
