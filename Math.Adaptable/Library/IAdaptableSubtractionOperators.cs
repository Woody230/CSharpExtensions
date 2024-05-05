using System.Numerics;

namespace Woody230.Math.Adaptable;
internal interface IAdaptableSubtractionOperators<TSelf> :
    ISubtractionOperators<TSelf, int, AdaptableNumber>,
    ISubtractionOperators<TSelf, long, AdaptableNumber>,
    ISubtractionOperators<TSelf, double, AdaptableNumber>,
    ISubtractionOperators<TSelf, decimal, AdaptableNumber>
    where TSelf: IAdaptableSubtractionOperators<TSelf>
{
}
