using System.Numerics;

namespace Woody230.Math.Operations;
internal readonly struct AdaptableLong(long value) :
    IAdditionOperators<AdaptableLong, int, AdaptableNumber>,
    IAdditionOperators<AdaptableLong, long, AdaptableNumber>,
    IAdditionOperators<AdaptableLong, double, AdaptableNumber>,
    IAdditionOperators<AdaptableLong, decimal, AdaptableNumber>,
    ISubtractionOperators<AdaptableLong, int, AdaptableNumber>,
    ISubtractionOperators<AdaptableLong, long, AdaptableNumber>,
    ISubtractionOperators<AdaptableLong, double, AdaptableNumber>,
    ISubtractionOperators<AdaptableLong, decimal, AdaptableNumber>,
    IMultiplyOperators<AdaptableLong, int, AdaptableNumber>,
    IMultiplyOperators<AdaptableLong, long, AdaptableNumber>,
    IMultiplyOperators<AdaptableLong, double, AdaptableNumber>,
    IMultiplyOperators<AdaptableLong, decimal, AdaptableNumber>,
    IDivisionOperators<AdaptableLong, int, AdaptableNumber>,
    IDivisionOperators<AdaptableLong, long, AdaptableNumber>,
    IDivisionOperators<AdaptableLong, double, AdaptableNumber>,
    IDivisionOperators<AdaptableLong, decimal, AdaptableNumber>,
    IFormattable
{
    private readonly long _value = value;

    public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

    public static AdaptableNumber operator +(AdaptableLong left, int right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableLong left, long right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableLong left, double right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableLong left, decimal right) => left._value + right;

    public static AdaptableNumber operator -(AdaptableLong left, int right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableLong left, long right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableLong left, double right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableLong left, decimal right) => left._value - right;

    public static AdaptableNumber operator *(AdaptableLong left, int right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableLong left, long right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableLong left, double right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableLong left, decimal right) => left._value * right;

    public static AdaptableNumber operator /(AdaptableLong left, int right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableLong left, long right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableLong left, double right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableLong left, decimal right) => left._value / right;

    public static implicit operator AdaptableLong(long value) => new(value);
    public static implicit operator long(AdaptableLong adaptable) => adaptable._value;
}
