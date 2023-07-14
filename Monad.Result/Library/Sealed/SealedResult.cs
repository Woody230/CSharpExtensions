namespace Woody230.Monad.Result.Sealed;

/// <summary>
/// Represents a specific case of an either, where one state represents failure and the other state represents success.
/// Additionally, the failure and success states represent a base state.
/// </summary>
/// <typeparam name="TRoot">The type of base state.</typeparam>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public class SealedResult<TRoot, TFailure, TSuccess> : Result<TFailure, TSuccess>, ISealedResult<TRoot, TFailure, TSuccess>
    where TRoot : notnull
    where TFailure : notnull, TRoot
    where TSuccess : notnull, TRoot
{
    /// <summary>
    /// Converts the <paramref name="result"/> is into a <see cref="SealedResult{TResult, TFailure, TSuccess}"/>.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <returns>The <see cref="SealedResult{TResult, TFailure, TSuccess}"/>.</returns>
    /// <exception cref="InvalidOperationException">If the result is not a <typeparamref name="TFailure"/> or <typeparamref name="TSuccess"/>.</exception>
    public static SealedResult<TRoot, TFailure, TSuccess> Of(TRoot result)
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

    /// <summary>
    /// Implicit converts the result to a success state.
    /// </summary>
    /// <param name="result">The result.</param>
    public static implicit operator TSuccess(SealedResult<TRoot, TFailure, TSuccess> result) => result.Success;

    /// <summary>
    /// Implicitly converts the result to a failure state.
    /// </summary>
    /// <param name="result">The result.</param>
    public static implicit operator TFailure(SealedResult<TRoot, TFailure, TSuccess> result) => result.Failure;

    /// <summary>
    /// Implicitly converts the result to a root state.
    /// </summary>
    /// <param name="result">The result.</param>
    public static implicit operator TRoot(SealedResult<TRoot, TFailure, TSuccess> result) => result.IsSuccess ? result.Success : result.Failure;

    /// <summary>
    /// Implicitly converts the success state to a result.
    /// </summary>
    /// <param name="success">The success state.</param>
    public static implicit operator SealedResult<TRoot, TFailure, TSuccess>(TSuccess success) => new(success);

    /// <summary>
    /// Implicitly converts the failure state to a result.
    /// </summary>
    /// <param name="failure">The failure state.</param>
    public static implicit operator SealedResult<TRoot, TFailure, TSuccess>(TFailure failure) => new(failure);

    /// <summary>
    /// Implicitly converts the root state to a result.
    /// </summary>
    /// <param name="root">The root state.</param>
    public static implicit operator SealedResult<TRoot, TFailure, TSuccess>(TRoot root) => Of(root);

    /// <summary>
    /// Applies an action on the result.
    /// </summary>
    /// <param name="onResult">The action to perform.</param>
    /// <returns>This result.</returns>
    public SealedResult<TRoot, TFailure, TSuccess> Apply(Action<TRoot> onResult)
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
    public TValue Fold<TValue>(Func<TRoot, TValue> onResult)
    {
        return IsSuccess ? onResult(Success) : onResult(Failure);
    }
}
