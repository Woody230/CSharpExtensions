using System.Numerics;

namespace Woody230.Math.Adaptable;
internal readonly struct AdaptableInt(int value) : 
    IAdditionOperators<AdaptableInt, int, AdaptableNumber>,
    IAdditionOperators<AdaptableInt, long, AdaptableNumber>,
    IAdditionOperators<AdaptableInt, double, AdaptableNumber>,
    IAdditionOperators<AdaptableInt, decimal, AdaptableNumber>,
    ISubtractionOperators<AdaptableInt, int, AdaptableNumber>,
    ISubtractionOperators<AdaptableInt, long, AdaptableNumber>,
    ISubtractionOperators<AdaptableInt, double, AdaptableNumber>,
    ISubtractionOperators<AdaptableInt, decimal, AdaptableNumber>,
    IMultiplyOperators<AdaptableInt, int, AdaptableNumber>,
    IMultiplyOperators<AdaptableInt, long, AdaptableNumber>,
    IMultiplyOperators<AdaptableInt, double, AdaptableNumber>,
    IMultiplyOperators<AdaptableInt, decimal, AdaptableNumber>,
    IDivisionOperators<AdaptableInt, int, AdaptableNumber>,
    IDivisionOperators<AdaptableInt, long, AdaptableNumber>,
    IDivisionOperators<AdaptableInt, double, AdaptableNumber>,
    IDivisionOperators<AdaptableInt, decimal, AdaptableNumber>,
    IPowerFunctions<int, AdaptableNumber>,
    IPowerFunctions<long, AdaptableNumber>,
    IPowerFunctions<double, AdaptableNumber>,
    IPowerFunctions<decimal, AdaptableNumber>,
    IFormattable
{
    private readonly int _value = value;

    public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

    public static AdaptableNumber operator +(AdaptableInt left, int right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableInt left, long right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableInt left, double right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableInt left, decimal right) => left._value + right;

    public static AdaptableNumber operator -(AdaptableInt left, int right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableInt left, long right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableInt left, double right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableInt left, decimal right) => left._value - right;

    public static AdaptableNumber operator *(AdaptableInt left, int right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableInt left, long right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableInt left, double right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableInt left, decimal right) => left._value * right;

    public static AdaptableNumber operator /(AdaptableInt left, int right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableInt left, long right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableInt left, double right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableInt left, decimal right) => left._value / right;

    public AdaptableNumber Pow(int power) => System.Math.Pow(_value, power);
    public AdaptableNumber Pow(long power) => System.Math.Pow(_value, power);
    public AdaptableNumber Pow(double power) => System.Math.Pow(_value, power);
    public AdaptableNumber Pow(decimal power) => System.Math.Pow(_value, Convert.ToDouble(power));

    public static implicit operator AdaptableInt(int value) => new(value);
    public static implicit operator int(AdaptableInt adaptable) => adaptable._value;
}
