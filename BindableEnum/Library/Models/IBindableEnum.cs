using System.Text.Json.Serialization;
using Woody230.BindableEnum.Converters;

namespace Woody230.BindableEnum.Models;

/// <summary>
/// Represents an enumeration that is bind safe.
/// </summary>
public interface IBindableEnum
{
    /// <summary>
    /// Whether the enum was able to be binded.
    /// </summary>
    public bool Binded { get; }

    /// <summary>
    /// The enumeration.
    /// </summary>
    public Enum Enum { get; }
}

/// <summary>
/// Represents an enumeration that is bind safe.
/// </summary>
/// <typeparam name="T">The type of enum.</typeparam>
[JsonConverter(typeof(BindableEnumConverterFactory))]
public interface IBindableEnum<T> : IBindableEnum where T: struct, Enum
{
    /// <summary>
    /// The enumeration.
    /// </summary>
    public new T Enum { get; }

    /// <inheritdoc/>
    Enum IBindableEnum.Enum => Enum;
}
