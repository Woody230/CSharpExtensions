using System.Text.Json;
using System.Text.Json.Serialization;

namespace Woody230.Text.Json.Converters;

/// <summary>
/// Converts a string to and from a <see cref="Uri"/> that is <see cref="UriKind.Absolute"/>.
/// </summary>
public sealed class AbsoluteUriJsonConverter : JsonConverter<Uri>
{
    /// <inheritdoc/>
    public override Uri Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.ReadUri(UriKind.Absolute);
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, Uri value, JsonSerializerOptions options)
    {
        writer.WriteUri(value);
    }
}
