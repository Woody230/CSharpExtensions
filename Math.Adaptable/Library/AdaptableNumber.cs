using System.Numerics;

namespace Woody230.Math.Adaptable;
public readonly struct AdaptableNumber : 
    IAdditionOperators<AdaptableNumber, AdaptableNumber, AdaptableNumber>,
    ISubtractionOperators<AdaptableNumber, AdaptableNumber, AdaptableNumber>,
    IMultiplyOperators<AdaptableNumber, AdaptableNumber, AdaptableNumber>,
    IDivisionOperators<AdaptableNumber, AdaptableNumber, AdaptableNumber>,
    IFormattable
{
    internal readonly Representation _representation;
    internal readonly AdaptableInt _int;
    internal readonly AdaptableLong _long;
    internal readonly AdaptableDouble _double;
    internal readonly AdaptableDecimal _decimal;

    internal enum Representation
    {
        Int,
        Long,
        Double,
        Decimal
    }

    public AdaptableNumber(int value)
    {
        _int = value;
        _representation = Representation.Int;
    }

    public AdaptableNumber(long value)
    {
        _long = value;
        _representation = Representation.Long;
    }

    public AdaptableNumber(double value)
    {
        _double = value;
        _representation = Representation.Double;
    }

    public AdaptableNumber(decimal value)
    {
        _decimal = value;
        _representation = Representation.Decimal;
    }

    public static implicit operator AdaptableNumber(int value) => new(value);
    public static implicit operator AdaptableNumber(long value) => new(value);
    public static implicit operator AdaptableNumber(double value) => new(value);
    public static implicit operator AdaptableNumber(decimal value) => new(value);

    public static AdaptableNumber operator +(AdaptableNumber left, AdaptableNumber right) => left.Add(right);
    public static AdaptableNumber operator -(AdaptableNumber left, AdaptableNumber right) => left.Subtract(right);
    public static AdaptableNumber operator *(AdaptableNumber left, AdaptableNumber right) => left.Multiply(right);
    public static AdaptableNumber operator /(AdaptableNumber left, AdaptableNumber right) => left.Divide(right);

    private AdaptableNumber Add(AdaptableNumber other) => _representation switch
    {
        Representation.Int => other._representation switch
        {
            Representation.Int => _int + other._int,
            Representation.Long => _int + other._long,
            Representation.Double => _int + other._double,
            Representation.Decimal => _int + other._decimal,
        },
        Representation.Long => other._representation switch
        {
            Representation.Int => _long + other._int,
            Representation.Long => _long + other._long,
            Representation.Double => _long + other._double,
            Representation.Decimal => _long + other._decimal,
        },
        Representation.Double => other._representation switch
        {
            Representation.Int => _double + other._int,
            Representation.Long => _double + other._long,
            Representation.Double => _double + other._double,
            Representation.Decimal => _double + other._decimal,
        },
        Representation.Decimal => other._representation switch
        {
            Representation.Int => _decimal + other._int,
            Representation.Long => _decimal + other._long,
            Representation.Double => _decimal + other._double,
            Representation.Decimal => _decimal + other._decimal,
        },
    };

    private AdaptableNumber Subtract(AdaptableNumber other) => _representation switch
    {
        Representation.Int => other._representation switch
        {
            Representation.Int => _int - other._int,
            Representation.Long => _int - other._long,
            Representation.Double => _int - other._double,
            Representation.Decimal => _int - other._decimal,
        },
        Representation.Long => other._representation switch
        {
            Representation.Int => _long - other._int,
            Representation.Long => _long - other._long,
            Representation.Double => _long - other._double,
            Representation.Decimal => _long - other._decimal,
        },
        Representation.Double => other._representation switch
        {
            Representation.Int => _double - other._int,
            Representation.Long => _double - other._long,
            Representation.Double => _double - other._double,
            Representation.Decimal => _double - other._decimal,
        },
        Representation.Decimal => other._representation switch
        {
            Representation.Int => _decimal - other._int,
            Representation.Long => _decimal - other._long,
            Representation.Double => _decimal - other._double,
            Representation.Decimal => _decimal - other._decimal,
        },
    };

    private AdaptableNumber Multiply(AdaptableNumber other) => _representation switch
    {
        Representation.Int => other._representation switch
        {
            Representation.Int => _int * other._int,
            Representation.Long => _int * other._long,
            Representation.Double => _int * other._double,
            Representation.Decimal => _int * other._decimal,
        },
        Representation.Long => other._representation switch
        {
            Representation.Int => _long * other._int,
            Representation.Long => _long * other._long,
            Representation.Double => _long * other._double,
            Representation.Decimal => _long * other._decimal,
        },
        Representation.Double => other._representation switch
        {
            Representation.Int => _double * other._int,
            Representation.Long => _double * other._long,
            Representation.Double => _double * other._double,
            Representation.Decimal => _double * other._decimal,
        },
        Representation.Decimal => other._representation switch
        {
            Representation.Int => _decimal * other._int,
            Representation.Long => _decimal * other._long,
            Representation.Double => _decimal * other._double,
            Representation.Decimal => _decimal * other._decimal,
        },
    };

    private AdaptableNumber Divide(AdaptableNumber other) => _representation switch
    {
        Representation.Int => other._representation switch
        {
            Representation.Int => _int / other._int,
            Representation.Long => _int / other._long,
            Representation.Double => _int / other._double,
            Representation.Decimal => _int / other._decimal,
        },
        Representation.Long => other._representation switch
        {
            Representation.Int => _long / other._int,
            Representation.Long => _long / other._long,
            Representation.Double => _long / other._double,
            Representation.Decimal => _long / other._decimal,
        },
        Representation.Double => other._representation switch
        {
            Representation.Int => _double / other._int,
            Representation.Long => _double / other._long,
            Representation.Double => _double / other._double,
            Representation.Decimal => _double / other._decimal,
        },
        Representation.Decimal => other._representation switch
        {
            Representation.Int => _decimal / other._int,
            Representation.Long => _decimal / other._long,
            Representation.Double => _decimal / other._double,
            Representation.Decimal => _decimal / other._decimal,
        },
    };

    public string ToString(string? format, IFormatProvider? formatProvider) => _representation switch
    {
        Representation.Int => _int.ToString(format, formatProvider),
        Representation.Long => _long.ToString(format, formatProvider),
        Representation.Double => _double.ToString(format, formatProvider),
        Representation.Decimal => _decimal.ToString(format, formatProvider),
    };
}
