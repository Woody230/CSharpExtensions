namespace Woody230.Monad.Result;

/// <summary>
/// Represents a specific case of an either, where one state represents failure and the other state represents success.
/// </summary>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public class Eithult<TFailure, TSuccess> : IEithult<TFailure, TSuccess> 
    where TFailure: notnull
    where TSuccess: notnull
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
    /// Initializes a new instance of the <see cref="Eithult{TFailure, TSuccess}"/> class as a failure.
    /// </summary>
    /// <param name="failure">The failure state.</param>
    public Eithult(TFailure failure)
    {
        IsSuccess = false;
        FailureOrNull = failure;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Eithult{TFailure, TSuccess}"/> class as a success.
    /// </summary>
    /// <param name="success">The success state.</param>
    public Eithult(TSuccess success)
    {
        IsSuccess = true;
        SuccessOrNull = success;
    }

    public static implicit operator TSuccess(Eithult<TFailure, TSuccess> result) => result.Success;
    public static implicit operator TFailure(Eithult<TFailure, TSuccess> result) => result.Failure;
    public static implicit operator Eithult<TFailure, TSuccess>(TSuccess success) => new(success);
    public static implicit operator Eithult<TFailure, TSuccess>(TFailure failure) => new(failure);

    /// <inheritdoc/>
    public TSuccess? SuccessOrNull { get; }

    /// <inheritdoc/>
    public TFailure? FailureOrNull { get; }

    /// <inheritdoc/>
    public override string? ToString() => IsSuccess ? Success.ToString() : Failure.ToString();

    /// <summary>
    /// Equality exists if <paramref name="obj"/> is a <see cref="Eithult{TFailure, TSuccess}"/> representing an equal success or failure state, or if the <paramref name="obj"/> is an equal success or failure state.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns>True if equal, otherwise false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is IEithult<TFailure, TSuccess> result)
        {
            return result.IsSuccess ? result.Equals(Success) : result.Equals(Failure);
        }

        return IsSuccess switch
        {
            true => obj is TSuccess success && success.Equals(Success),
            false => obj is TFailure failure && failure.Equals(Failure),
        };
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return IsSuccess ? Success.GetHashCode() : Failure.GetHashCode();
    }
}
