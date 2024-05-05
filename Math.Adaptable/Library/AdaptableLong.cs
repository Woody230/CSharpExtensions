namespace Woody230.Math.Adaptable;
internal readonly struct AdaptableLong(long value) : IAdaptableFunctions<AdaptableLong>
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

    public AdaptableNumber Pow(int power) => System.Math.Pow(_value, power);
    public AdaptableNumber Pow(long power) => System.Math.Pow(_value, power);
    public AdaptableNumber Pow(double power) => System.Math.Pow(_value, power);
    public AdaptableNumber Pow(decimal power) => System.Math.Pow(_value, power.ToDouble());

    public static implicit operator AdaptableLong(long value) => new(value);
    public static implicit operator long(AdaptableLong adaptable) => adaptable._value;
}
