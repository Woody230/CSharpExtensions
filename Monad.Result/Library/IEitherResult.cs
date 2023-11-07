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
}