using System.Diagnostics.CodeAnalysis;

namespace Woody230.Monad.Result;

/// <summary>
/// Represents a specific case of an either, where one state represents failure and the other state represents success.
/// </summary>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public interface IEitherResult<TFailure, TSuccess> : IFailureResult<TFailure>, ISuccessResult<TSuccess>
    where TFailure: notnull
    where TSuccess: notnull
{
    /// <summary>
    /// The success state, or null if the result is a failure.
    /// </summary>
    public TSuccess? SuccessOrNull { get; }

    /// <summary>
    /// The failure state, or null if the result is a success.
    /// </summary>
    public TFailure? FailureOrNull { get; }

    /// <summary>
    /// Transforms the state when it is a success.
    /// </summary>
    /// <typeparam name="TNewSuccess">The type of new success state.</typeparam>
    /// <param name="onSuccess">The delegate for transforming a success into a new success state.</param>
    /// <returns>The transformed result state.</returns>
    public IEitherResult<TFailure, TNewSuccess> Map<TNewSuccess>(Func<TSuccess, TNewSuccess> onSuccess) where TNewSuccess : notnull;

    /// <summary>
    /// Transforms the state when it is a failure.
    /// </summary>
    /// <typeparam name="TNewFailure">The type of new failure state.</typeparam>
    /// <param name="onFailure">The delegate for transforming a failure into a new failure state.</param>
    /// <returns>The transformed result state.</returns>
    public IEitherResult<TNewFailure, TSuccess> Map<TNewFailure>(Func<TFailure, TNewFailure> onFailure) where TNewFailure : notnull;

    /// <summary>
    /// Transforms the state depending on whether it is a failure or a success.
    /// </summary>
    /// <typeparam name="TNewFailure">The type of new failure state.</typeparam>
    /// <typeparam name="TNewSuccess">The type of new success state.</typeparam>
    /// <param name="onFailure">The delegate for transforming a failure into a new failure state.</param>
    /// <param name="onSuccess">The delegate for transforming a success into a new success state.</param>
    /// <returns>The transformed result state.</returns>
    public IEitherResult<TNewFailure, TNewSuccess> Map<TNewFailure, TNewSuccess>(
        Func<TFailure, TNewFailure> onFailure,
        Func<TSuccess, TNewSuccess> onSuccess
    ) where TNewFailure : notnull where TNewSuccess : notnull
    {
        return Map(onSuccess).Map(onFailure);
    }

    /// <summary>
    /// Transforms either possible state into a designated value.
    /// </summary>
    /// <typeparam name="TValue">The type of value.</typeparam>
    /// <param name="onFailure">The delegate for transforming a failure into the value.</param>
    /// <param name="onSuccess">The delegate for transforming a success into the value.</param>
    /// <returns>The value.</returns>
    public TValue Fold<TValue>(Func<TFailure, TValue> onFailure, Func<TSuccess, TValue> onSuccess)
    {
        return IsSuccess ? onSuccess(Success) : onFailure(Failure);
    }

    /// <summary>
    /// Applies the action when the result is a success.
    /// </summary>
    /// <param name="action">The action to perform on success.</param>
    /// <returns>This result.</returns>
    public IEitherResult<TFailure, TSuccess> OnSuccess(Action<TSuccess> action)
    {
        if (IsSuccess)
        {
            action(Success);
        }

        return this;
    }

    /// <summary>
    /// Applies the action when the result is a failure.
    /// </summary>
    /// <param name="action">The action to perform on failure.</param>
    /// <returns>This result.</returns>
    public IEitherResult<TFailure, TSuccess> OnFailure(Action<TFailure> action)
    {
        if (IsFailure)
        {
            action(Failure);
        }

        return this;
    }

    /// <summary>
    /// Applies an action depending on whether the result is a success or a failure.
    /// </summary>
    /// <param name="onFailure">The action to perform on failure.</param>
    /// <param name="onSuccess">The action to perform on success.</param>
    /// <returns>This result.</returns>
    public IEitherResult<TFailure, TSuccess> Apply(Action<TFailure> onFailure, Action<TSuccess> onSuccess)
    {
        return OnSuccess(onSuccess).OnFailure(onFailure);
    }

    /// <summary>
    /// Gets the success state if the result represents a success.
    /// </summary>
    /// <param name="success">The success state, or null if the result is a failure.</param>
    /// <returns>True if the result represents a success, otherwise false.</returns>
    public bool TrySuccess([NotNullWhen(returnValue: true)] out TSuccess? success)
    {
        if (IsSuccess)
        {
            success = Success;
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
    public bool TryFailure([NotNullWhen(returnValue: true)] out TFailure? failure)
    {
        if (IsFailure)
        {
            failure = Failure;
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
    public bool Equals(TSuccess success)
    {
        var isNull = Success == null && success == null;
        return IsSuccess && (isNull || Success?.Equals(success) == true);
    }

    /// <summary>
    /// Equality exists if this result is a failure and the failure state is equal to the given <paramref name="failure"/>.
    /// </summary>
    /// <param name="failure">The failure state to compare to.</param>
    /// <returns>True if equal, otherwise false.</returns>
    public bool Equals(TFailure failure)
    {
        var isNull = Failure == null && failure == null;
        return IsFailure && (isNull || Failure?.Equals(failure) == true);
    }
}