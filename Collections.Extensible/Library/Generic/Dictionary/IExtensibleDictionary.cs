using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="IDictionary{TKey, TValue}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
public interface IExtensibleDictionary<TKey, TValue>: IExtensibleCollection<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>
{
    #region Extended

    /// <summary>
    /// Adds a <paramref name="key"/> <paramref name="value"/> pair to this collection.
    /// </summary>
    public new IExtensibleDictionary<TKey, TValue> Add(TKey key, TValue value);

    /// <summary>
    /// Removes the <paramref name="key"/> value pair from this collection.
    /// </summary>
    public new IExtensibleDictionary<TKey, TValue> Remove(TKey key);

    /// <summary>
    /// Attempts to remove the <paramref name="key"/> value pair from this collection if it exists.
    /// </summary>
    /// <returns>True if the <paramref name="key"/> value pair exists, otherwise false.</returns>
    public bool TryRemove(TKey key);
    #endregion Extended

    #region Override
    void IDictionary<TKey, TValue>.Add(TKey key, TValue value) => Add(key, value);
    bool IDictionary<TKey, TValue>.Remove(TKey key) => TryRemove(key);
    #endregion Override

    #region Operators
    public static IExtensibleDictionary<TKey, TValue> operator +(IExtensibleDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other) => @this.AddAll(other);
    public static IExtensibleDictionary<TKey, TValue> operator -(IExtensibleDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other) => @this.RemoveAll(other);
    public static IExtensibleDictionary<TKey, TValue> operator +(IExtensibleDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        @this.Add(item);
        return @this;
    }
    public static IExtensibleDictionary<TKey, TValue> operator -(IExtensibleDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        @this.Remove(item);
        return @this;
    }
    #endregion Operators
}

/// <summary>
/// Represents a <see cref="IDictionary{TKey, TValue}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
/// <typeparam name="TCollection">The type of the implementation of the interface.</typeparam>
public interface IExtensibleDictionary<TKey, TValue, TCollection>: IExtensibleCollection<KeyValuePair<TKey, TValue>, TCollection>, IExtensibleDictionary<TKey, TValue> where TCollection: IExtensibleDictionary<TKey, TValue, TCollection>
{
    #region Extended

    /// <summary>
    /// Adds a <paramref name="key"/> <paramref name="value"/> pair to this collection.
    /// </summary>
    public new TCollection Add(TKey key, TValue value);

    /// <summary>
    /// Removes the <paramref name="key"/> value pair from this collection.
    /// </summary>
    public new TCollection Remove(TKey key);
    #endregion Extended

    #region Override

    /// <summary>
    /// Adds a <paramref name="key"/> <paramref name="value"/> pair to this collection.
    /// </summary>
    IExtensibleDictionary<TKey, TValue> IExtensibleDictionary<TKey, TValue>.Add(TKey key, TValue value) => Add(key, value);

    /// <summary>
    /// Removes the <paramref name="key"/> value pair from this collection.
    /// </summary>
    IExtensibleDictionary<TKey, TValue> IExtensibleDictionary<TKey, TValue>.Remove(TKey key) => Remove(key);
    #endregion Override

    #region Operators
    public static TCollection operator +(IExtensibleDictionary<TKey, TValue, TCollection> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        @this.AddAll(other);
        return (TCollection) @this;
    }
    public static TCollection operator -(IExtensibleDictionary<TKey, TValue, TCollection> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        @this.RemoveAll(other);
        return (TCollection) @this;
    }
    public static TCollection operator +(IExtensibleDictionary<TKey, TValue, TCollection> @this, KeyValuePair<TKey, TValue> item)
    {
        @this.Add(item);
        return (TCollection)@this;
    }
    public static TCollection operator -(IExtensibleDictionary<TKey, TValue, TCollection> @this, KeyValuePair<TKey, TValue> item)
    {
        @this.Remove(item);
        return (TCollection)@this;
    }
    #endregion Operators
}
