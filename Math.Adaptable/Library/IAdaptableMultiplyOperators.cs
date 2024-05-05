using System.Numerics;

namespace Woody230.Math.Adaptable;
internal interface IAdaptableMultiplyOperators<TSelf> :
    IMultiplyOperators<TSelf, int, AdaptableNumber>,
    IMultiplyOperators<TSelf, long, AdaptableNumber>,
    IMultiplyOperators<TSelf, double, AdaptableNumber>,
    IMultiplyOperators<TSelf, decimal, AdaptableNumber>
    where TSelf : IAdaptableMultiplyOperators<TSelf>
{
}
