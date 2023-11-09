namespace Woody230.Monad.Result;

/// <summary>
/// Represents a result where one state represents failure and the other state represents success.
/// </summary>
/// <typeparam name="TFailure">The type of failure.</typeparam>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public interface ISealedResult<TFailure, TSuccess> 
    where TFailure : IFailureResult, ISealedResult<TFailure, TSuccess>
    where TSuccess : ISuccessResult, ISealedResult<TFailure, TSuccess>
{
}
