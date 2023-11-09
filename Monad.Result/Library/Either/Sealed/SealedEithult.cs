namespace Woody230.Monad.Result;

/// <summary>
/// Represents a specific case of an either, where one state represents failure and the other state represents success.
/// Additionally, the failure and success states represent a base state.
/// </summary>
/// <typeparam name="TState">The type of base state.</typeparam>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public sealed class SealedEithult<TState, TFailure, TSuccess> : ISealedEithult<TState, TFailure, TSuccess>
    where TState : notnull
    where TFailure : notnull, TState
    where TSuccess : notnull, TState
{
    private readonly Eithult<TFailure, TSuccess> _result;

    /// <inheritdoc/>
    public bool IsSuccess => _result.IsSuccess;

    /// <inheritdoc/>
    public bool IsFailure => _result.IsFailure;

    /// <inheritdoc/>
    public TFailure Failure => _result.Failure;

    /// <inheritdoc/>
    public TSuccess Success => _result.Success;

    /// <inheritdoc/>
    public TFailure? FailureOrNull => _result.FailureOrNull;

    /// <inheritdoc/>
    public TSuccess? SuccessOrNull => _result.SuccessOrNull;

    /// <summary>
    /// Initializes a new instance of the <see cref="SealedEithult{TResult, TFailure, TSuccess}"/> class.
    /// </summary>
    /// <param name="state">The base state.</param>
    public SealedEithult(TState state)
    {
        _result = state switch
        {
            TSuccess success => new(success),
            TFailure failure => new(failure),
            _ => throw UnknownState()
        };

        InvalidOperationException UnknownState()
        {
            var successType = typeof(TSuccess).Name;
            var failureType = typeof(TFailure).Name;
            var actualType = state.GetType().Name;
            return new InvalidOperationException($"Expected the result to be a {successType} or {failureType} but it is a {actualType}.");
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SealedEithult{TResult, TFailure, TSuccess}"/> class.
    /// </summary>
    /// <param name="failure">The failure state.</param>
    public SealedEithult(TFailure failure)
    {
        _result = new(failure);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SealedEithult{TResult, TFailure, TSuccess}"/> class.
    /// </summary>
    /// <param name="success">The success state.</param>
    public SealedEithult(TSuccess success)
    {
        _result = new(success);
    }

    public static implicit operator TSuccess(SealedEithult<TState, TFailure, TSuccess> result) => result._result.Success;
    public static implicit operator TFailure(SealedEithult<TState, TFailure, TSuccess> result) => result._result.Failure;
    public static implicit operator TState(SealedEithult<TState, TFailure, TSuccess> result) => result.IsSuccess ? result.Success : result.Failure;
    public static implicit operator SealedEithult<TState, TFailure, TSuccess>(TSuccess success) => new(success);
    public static implicit operator SealedEithult<TState, TFailure, TSuccess>(TFailure failure) => new(failure);
    public static implicit operator SealedEithult<TState, TFailure, TSuccess>(TState root) => Of(root);

    /// <inheritdoc/>
    public override string? ToString() => _result.ToString();

    /// <summary>
    /// Equality exists if <paramref name="obj"/> is a <see cref="IEithult{TFailure, TSuccess}"/> representing an equal success or failure state, or if the <paramref name="obj"/> is an equal success or failure state.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns>True if equal, otherwise false.</returns>
    public override bool Equals(object? obj)
    {
        return _result.Equals(obj);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return _result.GetHashCode();
    }
}
