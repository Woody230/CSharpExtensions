using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="ICollection{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
/// <typeparam name="TCollection">The type of the implementation of the interface.</typeparam>
public interface IExtensibleCollection<T, TCollection> : ICollection<T> where TCollection: IExtensibleCollection<T, TCollection>
{
    /// <summary>
    /// Adds the <paramref name="item"/> to this collection.
    /// </summary>
    public new TCollection Add(T item);

    /// <summary>
    /// Copies this collection to the <paramref name="array"/> starting at <paramref name="arrayIndex"/>.
    /// </summary>
    public new TCollection CopyTo(T[] array, int arrayIndex);

    /// <summary>
    /// Removes the <paramref name="item"/> from this collection.
    /// </summary>
    public new TCollection Remove(T item);

    /// <summary>
    /// Attempts to remove the <paramref name="item"/> from the collection.
    /// </summary>
    /// <returns>True if the <paramref name="item"/> is removed, otherwise false.</returns>
    public bool TryRemove(T item);

    /// <summary>
    /// Adds each item in the <paramref name="other"/> collection to <paramref name="this"/> collection.
    /// </summary>
    public static TCollection operator +(IExtensibleCollection<T, TCollection> @this, IEnumerable<T> other)
    {
        @this.AddAll(other);
        return (TCollection)@this;
    }

    /// <summary>
    /// Removes each item in the <paramref name="other"/> collection from <paramref name="this"/> collection.
    /// </summary>
    public static TCollection operator -(IExtensibleCollection<T, TCollection> @this, IEnumerable<T> other)
    {
        @this.RemoveAll(other);
        return (TCollection)@this;
    }

    /// <summary>
    /// Adds the <paramref name="item"/> to <paramref name="this"/> collection.
    /// </summary>
    public static TCollection operator +(IExtensibleCollection<T, TCollection> @this, T item) => @this.Add(item);

    /// <summary>
    /// Removes the <paramref name="item"/> from <paramref name="this"/> collection.
    /// </summary>
    public static TCollection operator -(IExtensibleCollection<T, TCollection> @this, T item) => @this.Remove(item);
}
