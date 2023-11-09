namespace Woody230.Monad.Result;

/// <summary>
/// Represents extensions for a <see cref="ISealedEithult{TRoot, TFailure, TSuccess}"/>.
/// </summary>
public static class SealedEithultExtensions
{
    /// <summary>
    /// Applies an action on the result.
    /// </summary>
    /// <param name="onResult">The action to perform.</param>
    /// <returns>This result.</returns>
    public static ISealedEithult<TRoot, TFailure, TSuccess> Apply<TRoot, TFailure, TSuccess>(
        this ISealedEithult<TRoot, TFailure, TSuccess> @this,
        Action<TRoot> onResult
    )
        where TRoot: notnull
        where TFailure : notnull, TRoot
        where TSuccess : notnull, TRoot
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
    public static TValue Fold<TRoot, TFailure, TSuccess, TValue>(
        this ISealedEithult<TRoot, TFailure, TSuccess> @this,
        Func<TRoot, TValue> onResult
    )
        where TRoot : notnull
        where TFailure : notnull, TRoot
        where TSuccess : notnull, TRoot
    {
        return onResult(@this.IsSuccess ? @this.Success : @this.Failure);
    }
}
