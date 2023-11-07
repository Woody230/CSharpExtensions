namespace Woody230.Monad.Result;

/// <summary>
/// Represents a result that is successful.
/// </summary>
public interface ISuccessResult: IResult
{
    bool IResult.IsSuccess => true;
}

/// <summary>
/// Represents a result that is successful.
/// </summary>
/// <typeparam name="TSuccess">The type of success.</typeparam>
public interface ISuccessResult<TSuccess> : ISuccessResult
{
    /// <summary>
    /// The success state.
    /// </summary>
    public TSuccess Success { get; }
}