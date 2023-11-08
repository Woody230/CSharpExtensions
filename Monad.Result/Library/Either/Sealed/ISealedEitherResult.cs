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
}
