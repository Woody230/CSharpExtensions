namespace Woody230.Monad.Result;

/// <summary>
/// Represents a specific case of an either, where one state represents one or more failures and the other state represents one or more successes.
/// </summary>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public class Results<TFailure, TSuccess>: IResult<IEnumerable<TFailure>, IEnumerable<TSuccess>>
    where TFailure: notnull
    where TSuccess: notnull
{
    /// <inheritdoc/>
    public IEnumerable<TFailure> Failure => _failures;

    /// <inheritdoc/>
    public IEnumerable<TSuccess> Success => _successes;

    /// <summary>
    /// True if there are no failures.
    /// </summary>
    public bool IsSuccess => !Failure.Any();

    /// <summary>
    /// True if there are any failures.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    private readonly List<TFailure> _failures;
    private readonly List<TSuccess> _successes;

    /// <summary>
    /// Initializes a new instance of the <see cref="Results{TFailure, TSuccess}"/> class without any failures or successes.
    /// </summary>
    public Results(): this(new List<TFailure>(), new List<TSuccess>())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Results{TFailure, TSuccess}"/> class with failures.
    /// </summary>
    /// <param name="failures">The failures.</param>
    public Results(IEnumerable<TFailure> failures): this(failures, new List<TSuccess>())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Results{TFailure, TSuccess}"/> class with successes.
    /// </summary>
    /// <param name="successes">The successes.</param>
    public Results(IEnumerable<TSuccess> successes): this(new List<TFailure>(), successes)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Results{TFailure, TSuccess}"/> class with failures and successes.
    /// </summary>
    /// <param name="failures">The failures.</param>
    /// <param name="successes">The successes.</param>
    public Results(IEnumerable<TFailure> failures, IEnumerable<TSuccess> successes)
    {
        _failures = failures.ToList();
        _successes = successes.ToList();
    }

    /// <summary>
    /// Transforms each failure and success into a new state.
    /// </summary>
    /// <typeparam name="TNewFailure">The type of new failure state.</typeparam>
    /// <typeparam name="TNewSuccess">The type of new success state.</typeparam>
    /// <param name="onFailure">The delegate for transforming a failure into a new failure state.</param>
    /// <param name="onSuccess">The delegate for transforming a success into a new success state.</param>
    /// <returns>The transformed results.</returns>
    public Results<TNewFailure, TNewSuccess> Map<TNewFailure, TNewSuccess>(
        Func<TFailure, TNewFailure> onFailure,
        Func<TSuccess, TNewSuccess> onSuccess
    ) where TNewFailure : notnull where TNewSuccess : notnull
    {
        return Map(onSuccess).Map(onFailure);
    }

    /// <summary>
    /// Transforms each success into a new state.
    /// </summary>
    /// <typeparam name="TNewSuccess">The type of new success state.</typeparam>
    /// <param name="onSuccess">The delegate for transforming a success into a new success state.</param>
    /// <returns>The transformed results.</returns>
    public Results<TFailure, TNewSuccess> Map<TNewSuccess>(Func<TSuccess, TNewSuccess> onSuccess) where TNewSuccess : notnull
    {
        var successes = Success.Select(onSuccess);
        return new(Failure, successes);
    }

    /// <summary>
    /// Transforms each failure into a new state.
    /// </summary>
    /// <typeparam name="TNewFailure">The type of new failure state.</typeparam>
    /// <param name="onFailure">The delegate for transforming a failure into a new failure state.</param>
    /// <returns>The transformed result.</returns>
    public Results<TNewFailure, TSuccess> Map<TNewFailure>(Func<TFailure, TNewFailure> onFailure) where TNewFailure : notnull
    {
        var failures = Failure.Select(onFailure);
        return new(failures, Success);
    }

    /// <summary>
    /// Applies the action on each success.
    /// </summary>
    /// <param name="action">The action to perform on success.</param>
    /// <returns>This results.</returns>
    public Results<TFailure, TSuccess> OnSuccess(Action<TSuccess> action)
    {
        foreach (var success in Success)
        {
            action(success);
        }

        return this;
    }

    /// <summary>
    /// Applies the action on each failure.
    /// </summary>
    /// <param name="action">The action to perform on failure.</param>
    /// <returns>This results.</returns>
    public Results<TFailure, TSuccess> OnFailure(Action<TFailure> action)
    {
        foreach (var failure in Failure)
        {
            action(failure);
        }

        return this;
    }

    /// <summary>
    /// Applies an action on each failure and success state.
    /// </summary>
    /// <param name="onFailure">The action to perform on failure.</param>
    /// <param name="onSuccess">The action to perform on success.</param>
    /// <returns>This result.</returns>
    public Results<TFailure, TSuccess> Apply(Action<TFailure> onFailure, Action<TSuccess> onSuccess)
    {
        return OnSuccess(onSuccess).OnFailure(onFailure);
    }

    /// <summary>
    /// Transforms each failure and success state into the new value.
    /// </summary>
    /// <typeparam name="TValue">The type of value.</typeparam>
    /// <param name="onFailure">The delegate for transforming a failure into the value.</param>
    /// <param name="onSuccess">The delegate for transforming a success into the value.</param>
    /// <returns>The values.</returns>
    public IEnumerable<TValue> Fold<TValue>(Func<TFailure, TValue> onFailure, Func<TSuccess, TValue> onSuccess)
    {
        var newSuccesses = Success.Select(onSuccess);
        var newFailures = Failure.Select(onFailure);
        return newSuccesses.Concat(newFailures);
    }

    /// <summary>
    /// Transforms the collection of successes into a single success state of <typeparamref name="TNewSuccess"/>.
    /// If there are any failures, then the failures are transformed into a single failure state of <typeparamref name="TNewFailure"/>.
    /// </summary>
    /// <typeparam name="TNewFailure">The type of new failure state.</typeparam>
    /// <typeparam name="TNewSuccess">The type of new success state.</typeparam>
    /// <param name="onFailure">The delegate for transforming the failures into a new failure state.</param>
    /// <param name="onSuccess">The delegate for transforming the successes into a new success state.</param>
    /// <returns>The transformed result.</returns>
    public Result<TNewFailure, TNewSuccess> Flatten<TNewFailure, TNewSuccess>(Func<IEnumerable<TFailure>, TNewFailure> onFailure, Func<IEnumerable<TSuccess>, TNewSuccess> onSuccess)
        where TNewFailure : notnull
        where TNewSuccess : notnull
    {
        return IsSuccess ? onSuccess(Success) : onFailure(Failure);
    }

    /// <summary>
    /// Adds a failure state.
    /// </summary>
    /// <param name="failure">The failure state.</param>
    public void Add(TFailure failure)
    {
        _failures.Add(failure);
    }

    /// <summary>
    /// Adds a success state.
    /// </summary>
    /// <param name="success">The success state.</param>
    public void Add(TSuccess success)
    {
        _successes.Add(success);
    }

    /// <summary>
    /// Adds failure states.
    /// </summary>
    /// <param name="failures">The failures.</param>
    public void AddAll(IEnumerable<TFailure> failures)
    {
        foreach (var failure in failures)
        {
            Add(failure);
        }
    }

    /// <summary>
    /// Adds success states.
    /// </summary>
    /// <param name="successes">The successes.</param>
    /// <returns>This results.</returns>
    public void AddAll(IEnumerable<TSuccess> successes)
    {
        foreach (var success in successes)
        {
            Add(success);
        }
    }

    /// <summary>
    /// Adds a failure or success depending on the state of the result.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <returns>This results.</returns>
    public void Add(IResult<TFailure, TSuccess> result)
    {
        if (result.IsSuccess)
        {
            Add(result.Success);
        }
        else
        {
            Add(result.Failure);
        }
    }

    /// <summary>
    /// Adds each failure and success to this result.
    /// </summary>
    /// <param name="results">The results.</param>
    /// <returns>This results.</returns>
    public void AddAll(Results<TFailure, TSuccess> results)
    {
        AddAll(results.Success);
        AddAll(results.Failure);
    }
}
