using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Woody230.Text.Json.Converters;

/// <summary>
/// Represents extensions for a <see cref="Regex"/> <see cref="JsonConverter"/>
/// </summary>
internal static class RegexJsonConverterExtensions
{
    public static Regex ReadRegex(this ref Utf8JsonReader reader, RegexOptions options)
    {
        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to#jsonexception
        // If you throw a JsonException without a message, the serializer creates a message that includes the path to the part of the JSON that caused the error.
        var token = reader.GetString() ?? throw new JsonException();
        return new Regex(token, options);
    }

    public static void WriteRegex(this Utf8JsonWriter writer, Regex value)
    {
        writer.WriteStringValue(value.ToString());
    }
}
