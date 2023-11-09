using System.Diagnostics.CodeAnalysis;

namespace Woody230.Monad.Result;

/// <summary>
/// Represents extensions for an <see cref="IEithult{TFailure, TSuccess}"/>.
/// </summary>
public static class EithultExtensions
{
    /// <summary>
    /// Transforms the state when it is a success.
    /// </summary>
    /// <typeparam name="TNewSuccess">The type of new success state.</typeparam>
    /// <param name="onSuccess">The delegate for transforming a success into a new success state.</param>
    /// <returns>The transformed result state.</returns>
    public static IEithult<TFailure, TNewSuccess> MapSuccess<TFailure, TSuccess, TNewSuccess>(
        this IEithult<TFailure, TSuccess> @this, 
        Func<TSuccess, TNewSuccess> onSuccess
    )
        where TFailure : notnull
        where TSuccess : notnull
        where TNewSuccess : notnull
    {
        if (@this.IsSuccess)
        {
            var newSuccess = onSuccess(@this.Success);
            return new Eithult<TFailure, TNewSuccess>(newSuccess);
        }
        else
        {
            return new Eithult<TFailure, TNewSuccess>(@this.Failure);
        }
    }

    /// <summary>
    /// Transforms the state when it is a failure.
    /// </summary>
    /// <typeparam name="TNewFailure">The type of new failure state.</typeparam>
    /// <param name="onFailure">The delegate for transforming a failure into a new failure state.</param>
    /// <returns>The transformed result state.</returns>
    public static IEithult<TNewFailure, TSuccess> MapFailure<TFailure, TSuccess, TNewFailure>(
        this IEithult<TFailure, TSuccess> @this, 
        Func<TFailure, TNewFailure> onFailure
    )
        where TFailure: notnull
        where TSuccess: notnull
        where TNewFailure : notnull
    {
        if (@this.IsSuccess)
        {
            return new Eithult<TNewFailure, TSuccess>(@this.Success);
        }
        else
        {
            var newFailure = onFailure(@this.Failure);
            return new Eithult<TNewFailure, TSuccess>(newFailure);
        }
    }

    /// <summary>
    /// Transforms the state depending on whether it is a failure or a success.
    /// </summary>
    /// <typeparam name="TNewFailure">The type of new failure state.</typeparam>
    /// <typeparam name="TNewSuccess">The type of new success state.</typeparam>
    /// <param name="onFailure">The delegate for transforming a failure into a new failure state.</param>
    /// <param name="onSuccess">The delegate for transforming a success into a new success state.</param>
    /// <returns>The transformed result state.</returns>
    public static IEithult<TNewFailure, TNewSuccess> Map<TFailure, TSuccess, TNewFailure, TNewSuccess>(
        this IEithult<TFailure, TSuccess> @this,
        Func<TFailure, TNewFailure> onFailure,
        Func<TSuccess, TNewSuccess> onSuccess
    )
        where TFailure : notnull
        where TSuccess : notnull
        where TNewFailure : notnull 
        where TNewSuccess : notnull
    {
        return @this.MapSuccess(onSuccess).MapFailure(onFailure);
    }

    /// <summary>
    /// Transforms either possible state into a designated value.
    /// </summary>
    /// <typeparam name="TValue">The type of value.</typeparam>
    /// <param name="onFailure">The delegate for transforming a failure into the value.</param>
    /// <param name="onSuccess">The delegate for transforming a success into the value.</param>
    /// <returns>The value.</returns>
    public static TValue Fold<TFailure, TSuccess, TValue>(
        this IEithult<TFailure, TSuccess> @this,
        Func<TFailure, TValue> onFailure,
        Func<TSuccess, TValue> onSuccess
    )
        where TFailure: notnull
        where TSuccess: notnull
    {
        return @this.IsSuccess ? onSuccess(@this.Success) : onFailure(@this.Failure);
    }



    /// <summary>
    /// Applies the action when the result is a success.
    /// </summary>
    /// <param name="action">The action to perform on success.</param>
    /// <returns>This result.</returns>
    public static IEithult<TFailure, TSuccess> OnSuccess<TFailure, TSuccess>(this IEithult<TFailure, TSuccess> @this, Action<TSuccess> action)
        where TFailure: notnull
        where TSuccess: notnull
    {
        if (@this.IsSuccess)
        {
            action(@this.Success);
        }

        return @this;
    }

    /// <summary>
    /// Applies the action when the result is a failure.
    /// </summary>
    /// <param name="action">The action to perform on failure.</param>
    /// <returns>This result.</returns>
    public static IEithult<TFailure, TSuccess> OnFailure<TFailure, TSuccess>(this IEithult<TFailure, TSuccess> @this, Action<TFailure> action)
        where TFailure : notnull
        where TSuccess : notnull
    {
        if (@this.IsFailure)
        {
            action(@this.Failure);
        }

        return @this;
    }

    /// <summary>
    /// Applies an action depending on whether the result is a success or a failure.
    /// </summary>
    /// <param name="onFailure">The action to perform on failure.</param>
    /// <param name="onSuccess">The action to perform on success.</param>
    /// <returns>This result.</returns>
    public static IEithult<TFailure, TSuccess> Apply<TFailure, TSuccess>(this IEithult<TFailure, TSuccess> @this, Action<TFailure> onFailure, Action<TSuccess> onSuccess)
        where TFailure : notnull
        where TSuccess : notnull
    {
        return @this.OnSuccess(onSuccess).OnFailure(onFailure);
    }

    /// <summary>
    /// Gets the success state if the result represents a success.
    /// </summary>
    /// <param name="success">The success state, or null if the result is a failure.</param>
    /// <returns>True if the result represents a success, otherwise false.</returns>
    public static bool TrySuccess<TFailure, TSuccess>(this IEithult<TFailure, TSuccess> @this, [NotNullWhen(returnValue: true)] out TSuccess? success)
        where TFailure : notnull
        where TSuccess : notnull
    {
        if (@this.IsSuccess)
        {
            success = @this.Success;
            return true;
        }

        success = default;
        return false;
    }

    /// <summary>
    /// Gets the failure state if the result represents a failure.
    /// </summary>
    /// <param name="failure">The failure state, or null if the result is a success.</param>
    /// <returns>True if the result represents a failure, otherwise false.</returns>
    public static bool TryFailure<TFailure, TSuccess>(this IEithult<TFailure, TSuccess> @this, [NotNullWhen(returnValue: true)] out TFailure? failure)
        where TFailure : notnull
        where TSuccess : notnull
    {
        if (@this.IsFailure)
        {
            failure = @this.Failure;
            return true;
        }

        failure = default;
        return false;
    }

    /// <summary>
    /// Equality exists if this result is a success and the success state is equal to the given <paramref name="success"/>.
    /// </summary>
    /// <param name="success">The success state to compare to.</param>
    /// <returns>True if equal, otherwise false.</returns>
    public static bool Equals<TFailure, TSuccess>(this IEithult<TFailure, TSuccess> @this, TSuccess success)
        where TFailure : notnull
        where TSuccess : notnull
    {
        if (@this.IsFailure)
        {
            return false;
        }

        var thisSuccess = @this.SuccessOrNull;
        var isNull = thisSuccess == null && success == null;
        return isNull || thisSuccess?.Equals(success) == true;
    }

    /// <summary>
    /// Equality exists if this result is a failure and the failure state is equal to the given <paramref name="failure"/>.
    /// </summary>
    /// <param name="failure">The failure state to compare to.</param>
    /// <returns>True if equal, otherwise false.</returns>
    public static bool Equals<TFailure, TSuccess>(this IEithult<TFailure, TSuccess> @this, TFailure failure)
        where TFailure : notnull
        where TSuccess : notnull
    {
        if (@this.IsSuccess)
        {
            return false;
        }

        var thisFailure = @this.FailureOrNull;
        var isNull = thisFailure == null && failure == null;
        return isNull || thisFailure?.Equals(failure) == true;
    }
}
