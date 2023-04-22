using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Woody230.BindableEnum.Models;

namespace Woody230.BindableEnum.Converters
{
    /// <summary>
    /// Represents a factory for creating the converter for a <see cref="BindableEnum{T}"/>.
    /// </summary>
    public class BindableEnumConverterFactory : JsonConverterFactory
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType)
            {
                return false;
            }

            return typeToConvert.GetGenericTypeDefinition() == typeof(BindableEnum<>);
        }

        /// <inheritdoc/>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var wrappedType = typeToConvert.GetGenericArguments()[0];
            return (JsonConverter)Activator.CreateInstance(typeof(BindableEnumConverter<>).MakeGenericType(wrappedType));
        }
    }
}
