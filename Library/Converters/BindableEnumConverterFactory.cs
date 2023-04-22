﻿using BindableEnum.Library.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BindableEnum.Library.Converters
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
