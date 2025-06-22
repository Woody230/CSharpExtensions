using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Woody230.Text.Json.Converters;

/// <summary>
/// Converts a string to and from <see cref="Regex"/> using the <see cref="RegexOptions.Compiled"/> option.
/// </summary>
public sealed class CompiledRegexJsonConverter : JsonConverter<Regex>
{
    /// <inheritdoc/>
    public override Regex Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.ReadRegex(RegexOptions.Compiled);
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, Regex value, JsonSerializerOptions options)
    {
        writer.WriteRegex(value);
    }
}