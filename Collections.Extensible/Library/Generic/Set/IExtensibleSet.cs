using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="ISet{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
/// <typeparam name="TCollection">The type of the implementation of the interface.</typeparam>
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

    #region Operators
    public static IExtensibleSet<T> operator +(IExtensibleSet<T> @this, IEnumerable<T> other) => @this.AddAll(other);
    public static IExtensibleSet<T> operator -(IExtensibleSet<T> @this, IEnumerable<T> other) => @this.RemoveAll(other);
    public static IExtensibleSet<T> operator +(IExtensibleSet<T> @this, T item)
    {
        @this.Add(item);
        return @this;
    }
    public static IExtensibleSet<T> operator -(IExtensibleSet<T> @this, T item)
    {
        @this.Remove(item);
        return @this;
    }
    #endregion Operators
}

/// <summary>
/// Represents a <see cref="ISet{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
/// <typeparam name="TCollection">The type of the implementation of the interface.</typeparam>
public interface IExtensibleSet<T, TCollection> : IExtensibleCollection<T, TCollection>, IExtensibleSet<T> where TCollection : IExtensibleSet<T, TCollection>
{
    /// <summary>
    /// Adds the <paramref name="item"/> to this collection if it is not present in the collection already.
    /// </summary>
    public new TCollection Add(T item);

    IExtensibleSet<T> IExtensibleSet<T>.Add(T item) => Add(item);

    #region Operators

    public static TCollection operator +(IExtensibleSet<T, TCollection> @this, IEnumerable<T> other)
    {
        @this.AddAll(other);
        return (TCollection)@this;
    }

    public static TCollection operator -(IExtensibleSet<T, TCollection> @this, IEnumerable<T> other)
    {
        @this.RemoveAll(other);
        return (TCollection)@this;
    }

    public static TCollection operator +(IExtensibleSet<T, TCollection> @this, T item) => @this.Add(item);

    public static TCollection operator -(IExtensibleSet<T, TCollection> @this, T item) => @this.Remove(item);

    #endregion Operators
}