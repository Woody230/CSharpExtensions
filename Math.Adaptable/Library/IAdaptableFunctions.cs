namespace Woody230.Math.Adaptable;
internal interface IAdaptableFunctions<TSelf> :
    IAdaptableAdditionOperators<TSelf>,
    IAdaptableSubtractionOperators<TSelf>,
    IAdaptableMultiplyOperators<TSelf>,
    IAdaptableDivisionOperators<TSelf>,
    IAdaptablePowerFunctions,
    IFormattable
    where TSelf: IAdaptableFunctions<TSelf>
{
}
