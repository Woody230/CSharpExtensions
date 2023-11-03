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
