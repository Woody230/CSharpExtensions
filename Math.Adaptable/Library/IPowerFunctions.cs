namespace Woody230.Math.Adaptable;

public interface IPowerFunctions<TOther, TResult>
{
    /// <summary>
    /// Raises the numeric by the given <paramref name="power"/>.
    /// </summary>
    public TResult Pow(TOther power);
}
