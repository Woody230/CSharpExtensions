namespace Woody230.Math.Adaptable;
public static class AdaptableNumberExtensions
{
    public static AdaptableNumber ToAdaptableNumberOrZero(this object value, IFormatProvider? formatProvider = null) => value switch
    {
        int @int => @int,
        long @long => @long,
        double @double => @double,
        decimal @decimal => @decimal,
        string @string => ToAdaptableNumberOrZero(@string, formatProvider),
        _ => default
    };

    public static AdaptableNumber ToAdaptableNumberOrZero(this string value, IFormatProvider? formatProvider = null)
    {
        if (int.TryParse(value, formatProvider, out var @int))
        {
            return @int;
        }
        else if (long.TryParse(value, formatProvider, out var @long))
        {
            return @long;
        }
        else if (decimal.TryParse(value, formatProvider, out var @decimal))
        {
            return @decimal;
        }
        else if (double.TryParse(value, formatProvider, out var @double))
        {
            return @double;
        }
        else
        {
            return default;
        }
    }
}
