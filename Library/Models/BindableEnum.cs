using BindableEnum.Library.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace BindableEnum.Library.Models
{
    /// <summary>
    /// Represents a wrapper for a string associated with an enumeration.
    /// </summary>
    /// <typeparam name="T">The type of enum.</typeparam>
    [JsonConverter(typeof(BindableEnumConverterFactory))]
    public class BindableEnum<T> : IBindableEnum where T : struct, Enum
    {
        /// <summary>
        /// The enumeration.
        /// </summary>
        public T Enum { get; }

        /// <inheritdoc/>
        public bool Binded { get; }

        /// <inheritdoc/>
        Enum IBindableEnum.Enum => Enum;

        /// <summary>
        /// The string value.
        /// </summary>
        private string String { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BindableEnum{T}"/> structure.
        /// </summary>
        /// <param name="value">The string value.</param>
        public BindableEnum(string value)
        {
            String = value;

            if (System.Enum.TryParse<T>(value, false, out var @enum))
            {
                Enum = @enum;
                Binded = true;
            }
            else
            {
                Enum = default;
                Binded = false;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BindableEnum{T}"/> structure.
        /// </summary>
        /// <param name="enum">The enumeration.</param>
        public BindableEnum(T @enum)
        {
            String = @enum.ToString();
            Enum = @enum;
            Binded = true;
        }

        /// <inheritdoc/>
        public override string ToString() => String;

        /// <summary>
        /// Implicitly converts a bindable enum to the enum.
        /// </summary>
        /// <param name="bindable">The bindable enum.</param>
        public static implicit operator T(BindableEnum<T> bindable) => bindable.Enum;

        /// <summary>
        /// Implicitly converts the enum to a bindable enum.
        /// </summary>
        /// <param name="enum">The enum.</param>
        public static implicit operator BindableEnum<T>(T @enum) => new(@enum);
    }
}
