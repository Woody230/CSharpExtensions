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
    public TFailure Failure { get => _failure ?? throw new InvalidOperationException("Expected the result to be a failure but it is a success."); }

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">When the result is a failure.</exception>
    public TSuccess Success { get => _success ?? throw new InvalidOperationException("Expected the result to be a success but it is a failure."); }
    
    /// <inheritdoc/>
    public bool IsSuccess { get; }

    /// <summary>
    /// Whether the result is a failure.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    private readonly TFailure? _failure;
    private readonly TSuccess? _success;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TFailure, TSuccess}"/> class as a failure.
    /// </summary>
    /// <param name="failure">The failure state.</param>
    public Result(TFailure failure)
    {
        IsSuccess = false;
        _failure = failure;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TFailure, TSuccess}"/> class as a success.
    /// </summary>
    /// <param name="success">The success state.</param>
    public Result(TSuccess success)
    {
        IsSuccess = true;
        _success = success;
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
}
