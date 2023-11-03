using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="ISet{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public interface IExtensibleSet<T> : IExtensibleCollection<T>, ISet<T>
{
    /// <summary>
    /// Adds the <paramref name="item"/> to this collection if it is not present in the collection already.
    /// </summary>
    public new IExtensibleSet<T> Add(T item);

    /// <summary>
    /// Attempts to add the <paramref name="item"/> to the set if it is not present in the collection already.
    /// </summary>
    /// <returns>True if the <paramref name="item"/> is added to the set, otherwise false.</returns>
    public bool TryAdd(T item);

    /// <summary>
    /// Adds each item in the <paramref name="other"/> collection to <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleSet<T> operator +(IExtensibleSet<T> @this, IEnumerable<T> other) => @this.AddAll(other);

    /// <summary>
    /// Removes each item in the <paramref name="other"/> collection from <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleSet<T> operator -(IExtensibleSet<T> @this, IEnumerable<T> other) => @this.RemoveAll(other);

    /// <summary>
    /// Adds the <paramref name="item"/> to <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleSet<T> operator +(IExtensibleSet<T> @this, T item) => @this.Add(item);

    /// <summary>
    /// Removes the <paramref name="item"/> from <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleSet<T> operator -(IExtensibleSet<T> @this, T item)
    {
        @this.Remove(item);
        return @this;
    }
}
