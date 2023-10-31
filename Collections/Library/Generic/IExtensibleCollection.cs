using System;
using System.Collections.Generic;

namespace Woody230.Collections.Generic;

/// <summary>
/// Represents a <see cref="ICollection{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public interface IExtensibleCollection<T>: ICollection<T>
{
    /// <summary>
    /// Adds the <paramref name="item"/> to this collection.
    /// </summary>
    public new IExtensibleCollection<T> Add(T item);

    /// <summary>
    /// Copies this collection to the <paramref name="array"/> starting at <paramref name="arrayIndex"/>.
    /// </summary>
    public new IExtensibleCollection<T> CopyTo(T[] array, int arrayIndex);

    /// <summary>
    /// Adds each item in the <paramref name="collection"/> to this collection.
    /// </summary>
    public IExtensibleCollection<T> AddRange(IEnumerable<T> collection);

    /// <summary>
    /// Applies the <paramref name="action"/> to each item in the collection.
    /// </summary>
    public IExtensibleCollection<T> ForEach(Action<T> action);
}
