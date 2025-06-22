using System.Text.Json;
using System.Text.Json.Serialization;

namespace Woody230.Text.Json.Converters;

/// <summary>
/// Represents extensions for a <see cref="Uri"/> <see cref="JsonConverter"/>
/// </summary>
internal static class UriJsonConverterExtensions
{
    public static Uri ReadUri(this ref Utf8JsonReader reader, UriKind uriKind)
    {
        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to#jsonexception
        // If you throw a JsonException without a message, the serializer creates a message that includes the path to the part of the JSON that caused the error.
        var token = reader.GetString() ?? throw new JsonException();
        return new Uri(token, uriKind);
    }

    public static void WriteUri(this Utf8JsonWriter writer, Uri value)
    {
        writer.WriteStringValue(value.OriginalString);
    }
}
