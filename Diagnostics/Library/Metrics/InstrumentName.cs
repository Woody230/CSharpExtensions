using System.Diagnostics.Metrics;
using System.Text.Json.Serialization;

namespace Woody230.Diagnostics.Metrics;

/// <summary>
/// Represents the name of an <see cref="Instrument"/>
/// </summary>
public readonly struct InstrumentName
{
    private readonly string _value;
    public static implicit operator string(InstrumentName name) => name._value;
    public static implicit operator InstrumentName(string value) => new(value);

    [JsonConstructor]
    public InstrumentName(string value)
    {
        _value = value;
    }

    public override string ToString() => _value;

    public override bool Equals(object? obj)
    {
        return obj is InstrumentName name &&
               _value == name._value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_value);
    }

    public static bool operator ==(InstrumentName left, InstrumentName right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(InstrumentName left, InstrumentName right)
    {
        return !(left == right);
    }
}
