namespace Woody230.Monad.Result;

/// <summary>
/// Represents a result.
/// </summary>
public interface IResult
{
    /// <summary>
    /// Whether the result is a success.
    /// </summary>
    public bool IsSuccess { get; }
}
