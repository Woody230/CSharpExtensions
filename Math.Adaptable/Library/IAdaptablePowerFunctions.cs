namespace Woody230.Math.Adaptable;
internal interface IAdaptablePowerFunctions :
    IPowerFunctions<int, AdaptableNumber>,
    IPowerFunctions<long, AdaptableNumber>,
    IPowerFunctions<double, AdaptableNumber>,
    IPowerFunctions<decimal, AdaptableNumber>
{
}
