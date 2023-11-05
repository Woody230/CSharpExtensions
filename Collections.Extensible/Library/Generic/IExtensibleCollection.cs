using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="ICollection{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public interface IExtensibleCollection<T>: ICollection<T>
{
    /// <summary>
    /// Adds each item in the <paramref name="other"/> collection to <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleCollection<T> operator +(IExtensibleCollection<T> @this, IEnumerable<T> other)
    {
        @this.AddAll(other);
        return @this;
    }

    /// <summary>
    /// Removes each item in the <paramref name="other"/> collection from <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleCollection<T> operator -(IExtensibleCollection<T> @this, IEnumerable<T> other)
    {
        @this.RemoveAll(other);
        return @this;
    }

    /// <summary>
    /// Adds the <paramref name="item"/> to <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleCollection<T> operator +(IExtensibleCollection<T> @this, T item)
    {
        @this.Add(item);
        return @this;
    }

    /// <summary>
    /// Removes the <paramref name="item"/> from <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleCollection<T> operator -(IExtensibleCollection<T> @this, T item)
    {
        @this.Remove(item);
        return @this;
    }
}