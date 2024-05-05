using System.Numerics;

namespace Woody230.Math.Adaptable;
internal interface IAdaptableDivisionOperators<TSelf> :
    IDivisionOperators<TSelf, int, AdaptableNumber>,
    IDivisionOperators<TSelf, long, AdaptableNumber>,
    IDivisionOperators<TSelf, double, AdaptableNumber>,
    IDivisionOperators<TSelf, decimal, AdaptableNumber>
    where TSelf: IAdaptableDivisionOperators<TSelf>
{
}
