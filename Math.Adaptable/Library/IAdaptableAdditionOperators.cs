using System.Numerics;

namespace Woody230.Math.Adaptable;
internal interface IAdaptableAdditionOperators<TSelf> :
    IAdditionOperators<TSelf, int, AdaptableNumber>,
    IAdditionOperators<TSelf, long, AdaptableNumber>,
    IAdditionOperators<TSelf, double, AdaptableNumber>,
    IAdditionOperators<TSelf, decimal, AdaptableNumber>
    where TSelf : IAdaptableAdditionOperators<TSelf>
{
}
