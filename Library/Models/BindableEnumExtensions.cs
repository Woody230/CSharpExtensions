using System;

namespace Woody230.BindableEnum.Models
{
    /// <summary>
    /// Represents extensions for <see cref="IBindableEnum{T}"/> or <see cref="BindableEnum{T}"/>.
    /// </summary>
    public static class BindableEnumExtensions
    {
        /// <summary>
        /// Converts the <paramref name="enum"/> to a <see cref="IBindableEnum{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of enum.</typeparam>
        /// <param name="enum">The enumeration.</param>
        /// <returns>The <see cref="IBindableEnum{T}"/>.</returns>
        public static IBindableEnum<T> Bindable<T>(this T @enum) where T: struct, Enum
        {
            return new BindableEnum<T>(@enum);
        }

        /// <summary>
        /// Converts the nullable <paramref name="enum"/> to a <see cref="IBindableEnum{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of enum.</typeparam>
        /// <param name="enum">The nullable enumeration.</param>
        /// <returns>The <see cref="IBindableEnum{T}"/> if the <paramref name="enum"/> has a value, otherwise null.</returns>
        public static IBindableEnum<T> Bindable<T>(this T? @enum) where T : struct, Enum
        {
            if (!@enum.HasValue)
            {
                return null;
            }

            return new BindableEnum<T>(@enum.Value);
        }
    }
}
