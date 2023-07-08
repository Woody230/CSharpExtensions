using System;
using System.Linq;
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
        /// <summary>
        /// Determines whether the type can be converted.
        /// </summary>
        /// <param name="typeToConvert">The type is checked as to whether it can be converted.</param>
        /// <returns>True if the type is a <see cref="IBindableEnum{T}"/> or <see cref="BindableEnum{T}"/>.</returns>
        public override bool CanConvert(Type typeToConvert)
        {
            return TryResolveInterface(typeToConvert, out var _) || TryResolveClass(typeToConvert, out var _);
        }

        /// <summary>
        /// Create a converter for the provided <see cref="Type"/>.
        /// </summary>
        /// <param name="typeToConvert">The <see cref="Type"/> being converted.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> being used.</param>
        /// <returns>
        /// A <see cref="BindableEnumConverter{T}"/> if the type can be resolved to a <see cref="IBindableEnum"/> or <see cref="BindableEnum{T}"/>/
        /// Null if the type is null <see cref="IBindableEnum{T}"/> or <see cref="BindableEnum{T}"/>, which will throw a <see cref="NotSupportedException"/>.
        /// </returns>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            if (!TryResolveInterface(typeToConvert, out Type enumType) && !TryResolveClass(typeToConvert, out enumType))
            {
                return null;
            }

            return (JsonConverter)Activator.CreateInstance(typeof(BindableEnumConverter<>).MakeGenericType(enumType));
        }

        /// <summary>
        /// Resolves whether the type is a <see cref="IBindableEnum{T}"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="enumType">The type of the enum if the <paramref name="type"/> is a <see cref="IBindableEnum{T}"/>.</param>
        /// <returns>True if the type is a <see cref="IBindableEnum{T}"/>.</returns>
        private static bool TryResolveInterface(Type type, out Type enumType)
        {
            static bool IsBindableInterface(Type type) => type != null && type.IsAssignableTo(typeof(IBindableEnum<>));

            var @interface = type.GetInterfaces().FirstOrDefault(IsBindableInterface);
            if (@interface == null || !@interface.IsGenericType)
            {
                enumType = null;
                return false;
            }

            enumType = type.GetGenericArguments()[0];
            return true;
        }

        /// <summary>
        /// Resolves whether the type is a <see cref="BindableEnum{T}"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="enumType">The type of the enum if the <paramref name="type"/> is a <see cref="BindableEnum{T}"/>.</param>
        private static bool TryResolveClass(Type type, out Type enumType)
        {
            if (!type.IsGenericType)
            {
                enumType = null;
                return false;
            }

            enumType = type.GetGenericArguments()[0];
            return true;
        }
    }
}
