namespace Woody230.Math.Operations;
public static class AdaptableNumberExtensions
{
    public static AdaptableNumber ToAdaptableNumberOrZero(this object value) => value switch
    {
        int @int => @int,
        long @long => @long,
        double @double => @double,
        decimal @decimal => @decimal,
        string @string => ToAdaptableNumberOrZero(@string),
        _ => new AdaptableNumber()
    };

    public static AdaptableNumber ToAdaptableNumberOrZero(this string value)
    {
        if (int.TryParse(value, out var @int))
        {
            return @int;
        }
        else if (long.TryParse(value, out var @long))
        {
            return @long;
        }
        else if (decimal.TryParse(value, out var @decimal))
        {
            return @decimal;
        }
        else if (double.TryParse(value, out var @double))
        {
            return @double;
        }
        else
        {
            return new AdaptableNumber();
        }
    }
}
