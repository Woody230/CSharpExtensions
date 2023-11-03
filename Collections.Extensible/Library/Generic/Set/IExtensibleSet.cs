using System.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="ISet{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
/// <typeparam name="TCollection">The type of the implementation of the interface.</typeparam>
public interface IExtensibleSet<T, TCollection> : IExtensibleCollection<T, TCollection>, ISet<T> where TCollection : IExtensibleSet<T, TCollection>
{
    /// <summary>
    /// Adds the <paramref name="item"/> to this collection if it is not present in the collection already.
    /// </summary>
    public new TCollection Add(T item);

    /// <summary>
    /// Attempts to add the <paramref name="item"/> to the set if it is not present in the collection already.
    /// </summary>
    /// <returns>True if the <paramref name="item"/> is added to the set, otherwise false.</returns>
    public bool TryAdd(T item);
}