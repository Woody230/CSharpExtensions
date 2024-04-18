using System.Numerics;

namespace Woody230.Math.Operations;
internal readonly struct AdaptableDouble(double value) :
    IAdditionOperators<AdaptableDouble, int, AdaptableNumber>,
    IAdditionOperators<AdaptableDouble, long, AdaptableNumber>,
    IAdditionOperators<AdaptableDouble, double, AdaptableNumber>,
    IAdditionOperators<AdaptableDouble, decimal, AdaptableNumber>,
    ISubtractionOperators<AdaptableDouble, int, AdaptableNumber>,
    ISubtractionOperators<AdaptableDouble, long, AdaptableNumber>,
    ISubtractionOperators<AdaptableDouble, double, AdaptableNumber>,
    ISubtractionOperators<AdaptableDouble, decimal, AdaptableNumber>,
    IMultiplyOperators<AdaptableDouble, int, AdaptableNumber>,
    IMultiplyOperators<AdaptableDouble, long, AdaptableNumber>,
    IMultiplyOperators<AdaptableDouble, double, AdaptableNumber>,
    IMultiplyOperators<AdaptableDouble, decimal, AdaptableNumber>,
    IDivisionOperators<AdaptableDouble, int, AdaptableNumber>,
    IDivisionOperators<AdaptableDouble, long, AdaptableNumber>,
    IDivisionOperators<AdaptableDouble, double, AdaptableNumber>,
    IDivisionOperators<AdaptableDouble, decimal, AdaptableNumber>,
    IFormattable
{
    private readonly double _value = value;

    public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

    public static AdaptableNumber operator +(AdaptableDouble left, int right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableDouble left, long right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableDouble left, double right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableDouble left, decimal right) => Convert.ToDecimal(left._value) + right;

    public static AdaptableNumber operator -(AdaptableDouble left, int right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableDouble left, long right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableDouble left, double right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableDouble left, decimal right) => Convert.ToDecimal(left._value) - right;

    public static AdaptableNumber operator *(AdaptableDouble left, int right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableDouble left, long right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableDouble left, double right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableDouble left, decimal right) => Convert.ToDecimal(left._value) * right;

    public static AdaptableNumber operator /(AdaptableDouble left, int right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableDouble left, long right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableDouble left, double right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableDouble left, decimal right) => Convert.ToDecimal(left._value) / right;

    public static implicit operator AdaptableDouble(double value) => new(value);
    public static implicit operator double(AdaptableDouble adaptable) => adaptable._value;
}
