using BindableEnum.Library.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BindableEnum.Library.Converters
{
    /// <summary>
    /// Represents a converter for a <see cref="BindableEnum{T}"/>.
    /// </summary>
    public class BindableEnumConverter<T> : JsonConverter<BindableEnum<T>> where T : struct, Enum
    {
        /// <inheritdoc/>
        public override BindableEnum<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return new BindableEnum<T>(value);
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, BindableEnum<T> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.ToString(), options);
        }
    }
}
