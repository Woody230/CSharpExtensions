using System.Numerics;

namespace Woody230.Math.Operations;
internal readonly struct AdaptableDecimal(decimal value) :
    IAdditionOperators<AdaptableDecimal, int, AdaptableNumber>,
    IAdditionOperators<AdaptableDecimal, long, AdaptableNumber>,
    IAdditionOperators<AdaptableDecimal, double, AdaptableNumber>,
    IAdditionOperators<AdaptableDecimal, decimal, AdaptableNumber>,
    ISubtractionOperators<AdaptableDecimal, int, AdaptableNumber>,
    ISubtractionOperators<AdaptableDecimal, long, AdaptableNumber>,
    ISubtractionOperators<AdaptableDecimal, double, AdaptableNumber>,
    ISubtractionOperators<AdaptableDecimal, decimal, AdaptableNumber>,
    IMultiplyOperators<AdaptableDecimal, int, AdaptableNumber>,
    IMultiplyOperators<AdaptableDecimal, long, AdaptableNumber>,
    IMultiplyOperators<AdaptableDecimal, double, AdaptableNumber>,
    IMultiplyOperators<AdaptableDecimal, decimal, AdaptableNumber>,
    IDivisionOperators<AdaptableDecimal, int, AdaptableNumber>,
    IDivisionOperators<AdaptableDecimal, long, AdaptableNumber>,
    IDivisionOperators<AdaptableDecimal, double, AdaptableNumber>,
    IDivisionOperators<AdaptableDecimal, decimal, AdaptableNumber>,
    IFormattable
{
    private readonly decimal _value = value;

    public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

    public static AdaptableNumber operator +(AdaptableDecimal left, int right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableDecimal left, long right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableDecimal left, double right) => left._value + Convert.ToDecimal(right);
    public static AdaptableNumber operator +(AdaptableDecimal left, decimal right) => left._value + right;

    public static AdaptableNumber operator -(AdaptableDecimal left, int right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableDecimal left, long right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableDecimal left, double right) => left._value - Convert.ToDecimal(right);
    public static AdaptableNumber operator -(AdaptableDecimal left, decimal right) => left._value - right;

    public static AdaptableNumber operator *(AdaptableDecimal left, int right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableDecimal left, long right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableDecimal left, double right) => left._value * Convert.ToDecimal(right);
    public static AdaptableNumber operator *(AdaptableDecimal left, decimal right) => left._value * right;

    public static AdaptableNumber operator /(AdaptableDecimal left, int right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableDecimal left, long right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableDecimal left, double right) => left._value / Convert.ToDecimal(right);
    public static AdaptableNumber operator /(AdaptableDecimal left, decimal right) => left._value / right;

    public static implicit operator AdaptableDecimal(decimal value) => new(value);
    public static implicit operator decimal(AdaptableDecimal adaptable) => adaptable._value;
}

