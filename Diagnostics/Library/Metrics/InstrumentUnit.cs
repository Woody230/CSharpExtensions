using System.Diagnostics.Metrics;
using System.Text.Json.Serialization;

namespace Woody230.Diagnostics.Metrics;

/// <summary>
/// Represents a unit of measurement for an <see cref="Instrument"/>.
/// </summary>
[method: JsonConstructor]
/// <summary>
/// Represents a unit of measurement for an <see cref="Instrument"/>.
/// </summary>
public readonly struct InstrumentUnit(string value)
{
    private readonly string _value = value;
    public static implicit operator string(InstrumentUnit unit) => unit._value;
    public static implicit operator InstrumentUnit(string value) => new(value);

    public static readonly InstrumentUnit Day = new("d");
    public static readonly InstrumentUnit Hour = new("h");
    public static readonly InstrumentUnit Minute = new("min");
    public static readonly InstrumentUnit Second = new("s");
    public static readonly InstrumentUnit Millisecond = new("ms");
    public static readonly InstrumentUnit Microsecond = new("us");
    public static readonly InstrumentUnit Nanosecond = new("ns");
    public static readonly InstrumentUnit Unity = new("1");

    public override string ToString() => _value;

    public override bool Equals(object? obj)
    {
        return obj is InstrumentUnit unit &&
               _value == unit._value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_value);
    }

    public static bool operator ==(InstrumentUnit left, InstrumentUnit right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(InstrumentUnit left, InstrumentUnit right)
    {
        return !(left == right);
    }
}
