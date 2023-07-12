namespace Woody230.Monad.Result;

/// <summary>
/// Represents a specific case of an either, where one state represents failure and the other state represents success.
/// </summary>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public class Result<TFailure, TSuccess> : IResult<TFailure, TSuccess>
{
    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">When the result is a success.</exception>
    public TFailure Failure
    {
        get
        {
            if (IsSuccess)
            {
                throw new InvalidOperationException("Expected the result to be a failure but it is a success.");
            }

            return Failure;
        }
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">When the result is a failure.</exception>
    public TSuccess Success
    {
        get
        {
            if (IsFailure)
            {
                throw new InvalidOperationException("Expected the result to be a success but it is a failure.");
            }

            return Success;
        }
    }

    /// <inheritdoc/>
    public bool IsSuccess { get; }

    /// <summary>
    /// Whether the result is a failure.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// The success state, or null if the result is a failure.
    /// </summary>
    public TSuccess? SuccessOrNull { get; }

    /// <summary>
    /// The failure state, or null if the result is a success.
    /// </summary>
    public TFailure? FailureOrNull { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TFailure, TSuccess}"/> class as a failure.
    /// </summary>
    /// <param name="failure">The failure state.</param>
    public Result(TFailure failure)
    {
        IsSuccess = false;
        FailureOrNull = failure;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TFailure, TSuccess}"/> class as a success.
    /// </summary>
    /// <param name="success">The success state.</param>
    public Result(TSuccess success)
    {
        IsSuccess = true;
        SuccessOrNull = success;
    }

    /// <summary>
    /// Implicit converts the result to a success state.
    /// </summary>
    /// <param name="result">The result.</param>
    public static implicit operator TSuccess(Result<TFailure, TSuccess> result) => result.Success;

    /// <summary>
    /// Implicitly converts the result to a failure state.
    /// </summary>
    /// <param name="result">The result.</param>
    public static implicit operator TFailure(Result<TFailure, TSuccess> result) => result.Failure;

    /// <summary>
    /// Implicitly converts the success state to a result.
    /// </summary>
    /// <param name="success">The success state.</param>
    public static implicit operator Result<TFailure, TSuccess>(TSuccess success) => new(success);

    /// <summary>
    /// Implicitly converts the failure state to a result.
    /// </summary>
    /// <param name="failure">The failure state.</param>
    public static implicit operator Result<TFailure, TSuccess>(TFailure failure) => new(failure);

    /// <summary>
    /// Transforms the state depending on whether it is a failure or a success.
    /// </summary>
    /// <typeparam name="TNewFailure">The type of new failure state.</typeparam>
    /// <typeparam name="TNewSuccess">The type of new success state.</typeparam>
    /// <param name="onFailure">The delegate for transforming a failure into the new failure state.</param>
    /// <param name="onSuccess">The delegate for transforming a success into a new success state.</param>
    /// <returns>The transformed result state.</returns>
    public Result<TNewFailure, TNewSuccess> Fold<TNewFailure, TNewSuccess>(Func<TFailure, TNewFailure> onFailure, Func<TSuccess, TNewSuccess> onSuccess)
    {
        return Map(onSuccess).Map(onFailure);
    }

    /// <summary>
    /// Transforms the state when it is a success.
    /// </summary>
    /// <typeparam name="TNewSuccess">The type of new success state.</typeparam>
    /// <param name="onSuccess">The delegate for transforming a success into a new success state.</param>
    /// <returns>The transformed result state.</returns>
    public Result<TFailure, TNewSuccess> Map<TNewSuccess>(Func<TSuccess, TNewSuccess> onSuccess)
    {
        return IsSuccess ? new(onSuccess(Success)) : new(Failure);
    }

    /// <summary>
    /// Transforms the state when it is a failure.
    /// </summary>
    /// <typeparam name="TNewFailure">The type of new failure state.</typeparam>
    /// <param name="onFailure">The delegate for transforming a failure into the new failure state.</param>
    /// <returns>The transformed result state.</returns>
    public Result<TNewFailure, TSuccess> Map<TNewFailure>(Func<TFailure, TNewFailure> onFailure)
    {
        return IsSuccess ? new(Success) : new(onFailure(Failure));
    }

    /// <summary>
    /// Applies the action when the result is a success.
    /// </summary>
    /// <param name="action">The action to perform on success.</param>
    /// <returns>This result.</returns>
    public Result<TFailure, TSuccess> OnSuccess(Action<TSuccess> action)
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
    public Result<TFailure, TSuccess> OnFailure(Action<TFailure> action)
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
    public Result<TFailure, TSuccess> Apply(Action<TFailure> onFailure, Action<TSuccess> onSuccess)
    {
        return OnSuccess(onSuccess).OnFailure(onFailure);
    }

    /// <summary>
    /// Transforms either possible state into a designated value.
    /// </summary>
    /// <typeparam name="TValue">The type of value.</typeparam>
    /// <param name="onFailure">The delegate for transforming a failure into the value.</param>
    /// <param name="onSuccess">The delegate for transforming a success into the value.</param>
    /// <returns></returns>
    public TValue Flatten<TValue>(Func<TFailure, TValue> onFailure, Func<TSuccess, TValue> onSuccess)
    {
        return IsSuccess ? onSuccess(Success) : onFailure(Failure);
    }

    /// <inheritdoc/>
    public override string? ToString() => IsSuccess ? Success?.ToString() : Failure?.ToString();

    /// <summary>
    /// Equality exists if <paramref name="obj"/> is a <see cref="Result{TFailure, TSuccess}"/> representing an equal success or failure state, or if the <paramref name="obj"/> is an equal success or failure state.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns>True if equal, otherwise false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is IResult<TFailure, TSuccess> result)
        {
            return result.IsSuccess ? result.Equals(Success) : result.Equals(Failure);
        }

        return IsSuccess switch
        {
            true => obj is TSuccess s && s.Equals(Success),
            false => obj is TFailure f && f.Equals(Failure),
        };
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hashCode = IsSuccess ? Success?.GetHashCode() : Failure?.GetHashCode();
        return hashCode ?? 0;
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
