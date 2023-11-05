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
    public static IExtensibleDictionary<TKey, TValue> operator +(IExtensibleDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        @this.AddAll(other);
        return @this;
    }
    public static IExtensibleDictionary<TKey, TValue> operator -(IExtensibleDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        @this.RemoveKeys(other);
        return @this;
    }
    public static IExtensibleDictionary<TKey, TValue> operator +(IExtensibleDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        @this.Add(item);
        return @this;
    }
    public static IExtensibleDictionary<TKey, TValue> operator -(IExtensibleDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        @this.RemoveKey(item);
        return @this;
    }
    #endregion Operators
}
