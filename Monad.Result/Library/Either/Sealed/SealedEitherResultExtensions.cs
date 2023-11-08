namespace Woody230.Monad.Result;

/// <summary>
/// Represents extensions for a <see cref="ISealedEitherResult{TState, TFailure, TSuccess}"/>.
/// </summary>
public static class SealedEitherResultExtensions
{
    /// <summary>
    /// Applies an action on the result.
    /// </summary>
    /// <param name="onResult">The action to perform.</param>
    /// <returns>This result.</returns>
    public static ISealedEitherResult<TState, TFailure, TSuccess> Apply<TState, TFailure, TSuccess>(
        this ISealedEitherResult<TState, TFailure, TSuccess> @this,
        Action<TState> onResult
    )
        where TState: notnull
        where TFailure : notnull, TState
        where TSuccess : notnull, TState
    {
        if (@this.IsSuccess)
        {
            onResult(@this.Success);
        }
        else
        {
            onResult(@this.Failure);
        }

        return @this;
    }

    /// <summary>
    /// Transforms either possible state into a designated value.
    /// </summary>
    /// <typeparam name="TValue">The type of value.</typeparam>
    /// <param name="onResult">The delegate for transforming the result into the value.</param>
    /// <returns>The value.</returns>
    public static TValue Fold<TState, TFailure, TSuccess, TValue>(
        this ISealedEitherResult<TState, TFailure, TSuccess> @this,
        Func<TState, TValue> onResult
    )
        where TState : notnull
        where TFailure : notnull, TState
        where TSuccess : notnull, TState
    {
        return onResult(@this.IsSuccess ? @this.Success : @this.Failure);
    }
}
