namespace Woody230.Math.Adaptable;
internal readonly struct AdaptableInt(int value) : IAdaptableFunctions<AdaptableInt>
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
    public AdaptableNumber Pow(decimal power) => System.Math.Pow(_value, power.ToDouble());

    public static implicit operator AdaptableInt(int value) => new(value);
    public static implicit operator int(AdaptableInt adaptable) => adaptable._value;
}
