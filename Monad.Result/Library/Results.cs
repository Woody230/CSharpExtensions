namespace Woody230.Monad.Result;

/// <summary>
/// Represents a specific case of an either, where one state represents one or more failures and the other state represents one or more successes.
/// </summary>
/// <typeparam name="TFailure"></typeparam>
/// <typeparam name="TSuccess"></typeparam>
public class Results<TFailure, TSuccess>: IResult<IEnumerable<TFailure>, IEnumerable<TSuccess>>
{
    /// <inheritdoc/>
    public IEnumerable<TFailure> Failure => _failures;

    /// <inheritdoc/>
    public IEnumerable<TSuccess> Success => _successes;

    /// <summary>
    /// True if there are no failure states.
    /// </summary>
    public bool IsSuccess => !Failure.Any();

    /// <summary>
    /// True if there are any f
    /// </summary>
    public bool IsFailure => !IsSuccess;

    private readonly List<TFailure> _failures = new();
    private readonly List<TSuccess> _successes = new();

    /// <summary>
    /// Adds a failure state.
    /// </summary>
    /// <param name="failure">The failure state.</param>
    /// <returns>This result.</returns>
    public Results<TFailure, TSuccess> Add(TFailure failure)
    {
        _failures.Add(failure);
        return this;
    }

    /// <summary>
    /// Adds a success state.
    /// </summary>
    /// <param name="success">The success state.</param>
    /// <returns>This result.</returns>
    public Results<TFailure, TSuccess> Add(TSuccess success)
    {
        _successes.Add(success);
        return this;
    }

    /// <summary>
    /// Adds a failure or success state depending on the state of the result.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <returns>This result.</returns>
    public Results<TFailure, TSuccess> Add(IResult<TFailure, TSuccess> result)
    {
        if (result.IsSuccess)
        {
            _successes.Add(result.Success);
        }
        else
        {
            _failures.Add(result.Failure);
        }

        return this;
    }
}
