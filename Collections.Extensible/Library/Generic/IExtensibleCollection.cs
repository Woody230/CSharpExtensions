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
    /// Creates a new instance of the collection with the same elements.
    /// </summary>
    public IExtensibleCollection<T> ShallowCopy();

    /// <summary>
    /// Adds each item in the <paramref name="other"/> collection to a copy of <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleCollection<T> operator +(IExtensibleCollection<T> @this, IEnumerable<T> other)
    {
        var copy = @this.ShallowCopy();
        copy.AddAll(other);
        return copy;
    }

    /// <summary>
    /// Removes each item in the <paramref name="other"/> collection from a copy of <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleCollection<T> operator -(IExtensibleCollection<T> @this, IEnumerable<T> other)
    {
        var copy = @this.ShallowCopy();
        copy.RemoveAll(other);
        return copy;
    }

    /// <summary>
    /// Adds the <paramref name="item"/> to a copy of <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleCollection<T> operator +(IExtensibleCollection<T> @this, T item)
    {
        var copy = @this.ShallowCopy();
        copy.Add(item);
        return copy;
    }

    /// <summary>
    /// Removes the <paramref name="item"/> from a copy of <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleCollection<T> operator -(IExtensibleCollection<T> @this, T item)
    {
        var copy = @this.ShallowCopy();
        copy.Remove(item);
        return copy;
    }
}