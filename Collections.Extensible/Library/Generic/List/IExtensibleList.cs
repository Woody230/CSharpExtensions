using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="IList{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public interface IExtensibleList<T> : IExtensibleCollection<T>, IList<T>
{
    #region Operators
    public static IExtensibleList<T> operator +(IExtensibleList<T> @this, IEnumerable<T> other) => @this.AddAll(other);
    public static IExtensibleList<T> operator -(IExtensibleList<T> @this, IEnumerable<T> other) => @this.RemoveAll(other);
    public static IExtensibleList<T> operator +(IExtensibleList<T> @this, T item)
    {
        @this.Add(item);
        return @this;
    }
    public static IExtensibleList<T> operator -(IExtensibleList<T> @this, T item)
    {
        @this.Remove(item);
        return @this;
    }
    #endregion Operators
}

/// <summary>
/// Represents a <see cref="IList{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
/// /// <typeparam name="TCollection">The type of the implementation of the interface.</typeparam>
public interface IExtensibleList<T, TCollection> : IExtensibleCollection<T, TCollection>, IExtensibleList<T> where TCollection : IExtensibleList<T, TCollection>
{
    #region Operators

    public static TCollection operator +(IExtensibleList<T, TCollection> @this, IEnumerable<T> other)
    {
        @this.AddAll(other);
        return (TCollection)@this;
    }

    public static TCollection operator -(IExtensibleList<T, TCollection> @this, IEnumerable<T> other)
    {
        @this.RemoveAll(other);
        return (TCollection)@this;
    }

    public static TCollection operator +(IExtensibleList<T, TCollection> @this, T item) => @this.Add(item);

    /// <summary>
    /// Removes the <paramref name="item"/> from <paramref name="this"/> collection.
    /// </summary>
    public static TCollection operator -(IExtensibleList<T, TCollection> @this, T item) => @this.Remove(item);

    #endregion Operators
}
