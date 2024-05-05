namespace Woody230.Math.Adaptable;
internal readonly struct AdaptableDouble(double value) : IAdaptableFunctions<AdaptableDouble>
{
    private readonly double _value = value;

    public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

    public static AdaptableNumber operator +(AdaptableDouble left, int right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableDouble left, long right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableDouble left, double right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableDouble left, decimal right) => left._value.ToDecimal() + right;

    public static AdaptableNumber operator -(AdaptableDouble left, int right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableDouble left, long right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableDouble left, double right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableDouble left, decimal right) => left._value.ToDecimal() - right;

    public static AdaptableNumber operator *(AdaptableDouble left, int right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableDouble left, long right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableDouble left, double right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableDouble left, decimal right) => left._value.ToDecimal() * right;

    public static AdaptableNumber operator /(AdaptableDouble left, int right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableDouble left, long right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableDouble left, double right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableDouble left, decimal right) => left._value.ToDecimal() / right;

    public AdaptableNumber Pow(int power) => System.Math.Pow(_value, power);
    public AdaptableNumber Pow(long power) => System.Math.Pow(_value, power);
    public AdaptableNumber Pow(double power) => System.Math.Pow(_value, power);
    public AdaptableNumber Pow(decimal power) => System.Math.Pow(_value, power.ToDouble());

    public static implicit operator AdaptableDouble(double value) => new(value);
    public static implicit operator double(AdaptableDouble adaptable) => adaptable._value;
}
