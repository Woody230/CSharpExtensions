using System;
using System.Text.Json.Serialization;
using Woody230.BindableEnum.Converters;

namespace Woody230.BindableEnum.Models
{
    /// <summary>
    /// Represents a wrapper for a string associated with an enumeration.
    /// </summary>
    /// <typeparam name="T">The type of enum.</typeparam>
    [JsonConverter(typeof(BindableEnumConverterFactory))]
    public class BindableEnum<T> : IBindableEnum<T> where T : struct, Enum
    {
        /// <inheritdoc/>
        public T Enum { get; }

        /// <inheritdoc/>
        public bool Binded { get; }

        /// <summary>
        /// The string value.
        /// </summary>
        private string String { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BindableEnum{T}"/> class.
        /// </summary>
        /// <param name="value">The string value.</param>
        public BindableEnum(string value)
        {
            String = value;

            if (TryParse(value, out var @enum))
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
        /// Initializes a new instance of the <see cref="BindableEnum{T}"/> class.
        /// </summary>
        /// <param name="enum">The enumeration.</param>
        public BindableEnum(T @enum)
        {
            String = ToString(@enum);
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
        /// Implicitly converts a bindable enum to the nullable enum.
        /// </summary>
        /// <param name="bindable">The bindable enum.</param>
        public static implicit operator T?(BindableEnum<T> bindable) => bindable?.Enum;

        /// <summary>
        /// Implicitly converts the enum to a bindable enum.
        /// </summary>
        /// <param name="enum">The enum.</param>
        public static implicit operator BindableEnum<T>(T @enum) => new(@enum);

        /// <summary>
        /// Implicitly converts the nullable enum to a bindable enum.
        /// </summary>
        /// <param name="enum">The enum.</param>
        public static implicit operator BindableEnum<T>(T? @enum) => @enum.HasValue ? new(@enum.Value) : null;

        /// <summary>
        /// Tries to parse the enumeration from the string <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="enum">The enumeration.</param>
        /// <returns>True if the enumeration is successfully parsed.</returns>
        protected virtual bool TryParse(string value, out T @enum) => System.Enum.TryParse(value, false, out @enum);

        /// <summary>
        /// Converts the enumeration to its string form.
        /// </summary>
        /// <param name="enum">The enumeration.</param>
        /// <returns>The string form of the enumeration.</returns>
        protected virtual string ToString(T @enum) => @enum.ToString();
    }
}
