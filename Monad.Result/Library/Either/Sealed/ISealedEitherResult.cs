namespace Woody230.Monad.Result;
/// <summary>
/// Represents a specific case of an either, where one state represents failure and the other state represents success.
/// Additionally, the failure and success states represent a base state.
/// </summary>
/// <typeparam name="TState">The type of base state.</typeparam>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public interface ISealedEitherResult<TState, TFailure, TSuccess> : IEitherResult<TFailure, TSuccess>
    where TState : notnull
    where TFailure : notnull, TState
    where TSuccess : notnull, TState
{
    /// <summary>
    /// Applies an action on the result.
    /// </summary>
    /// <param name="onResult">The action to perform.</param>
    /// <returns>This result.</returns>
    public ISealedEitherResult<TState, TFailure, TSuccess> Apply(Action<TState> onResult)
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
