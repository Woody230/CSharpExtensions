namespace Woody230.Math.Adaptable;
internal readonly struct AdaptableDecimal(decimal value) : IAdaptableFunctions<AdaptableDecimal>
{
    private readonly decimal _value = value;

    public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

    public static AdaptableNumber operator +(AdaptableDecimal left, int right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableDecimal left, long right) => left._value + right;
    public static AdaptableNumber operator +(AdaptableDecimal left, double right) => left._value + right.ToDecimal();
    public static AdaptableNumber operator +(AdaptableDecimal left, decimal right) => left._value + right;

    public static AdaptableNumber operator -(AdaptableDecimal left, int right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableDecimal left, long right) => left._value - right;
    public static AdaptableNumber operator -(AdaptableDecimal left, double right) => left._value - right.ToDecimal();
    public static AdaptableNumber operator -(AdaptableDecimal left, decimal right) => left._value - right;

    public static AdaptableNumber operator *(AdaptableDecimal left, int right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableDecimal left, long right) => left._value * right;
    public static AdaptableNumber operator *(AdaptableDecimal left, double right) => left._value * right.ToDecimal();
    public static AdaptableNumber operator *(AdaptableDecimal left, decimal right) => left._value * right;

    public static AdaptableNumber operator /(AdaptableDecimal left, int right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableDecimal left, long right) => left._value / right;
    public static AdaptableNumber operator /(AdaptableDecimal left, double right) => left._value / right.ToDecimal();
    public static AdaptableNumber operator /(AdaptableDecimal left, decimal right) => left._value / right;

    public AdaptableNumber Pow(int power) => System.Math.Pow(_value.ToDouble(), power);
    public AdaptableNumber Pow(long power) => System.Math.Pow(_value.ToDouble(), power);
    public AdaptableNumber Pow(double power) => System.Math.Pow(_value.ToDouble(), power);
    public AdaptableNumber Pow(decimal power) => System.Math.Pow(_value.ToDouble(), power.ToDouble());

    public static implicit operator AdaptableDecimal(decimal value) => new(value);
    public static implicit operator decimal(AdaptableDecimal adaptable) => adaptable._value;
}

