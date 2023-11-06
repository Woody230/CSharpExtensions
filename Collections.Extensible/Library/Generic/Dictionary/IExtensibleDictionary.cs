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
    /// <summary>
    /// Creates a new instance of the collection.
    /// </summary>
    public new IExtensibleDictionary<TKey, TValue> ShallowCopy();

    IExtensibleCollection<KeyValuePair<TKey, TValue>> IExtensibleCollection<KeyValuePair<TKey, TValue>>.ShallowCopy() => ShallowCopy();

    #region Operators
    public static IExtensibleDictionary<TKey, TValue> operator +(IExtensibleDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        var copy = @this.ShallowCopy();
        copy.AddAll(other);
        return copy;
    }
    public static IExtensibleDictionary<TKey, TValue> operator -(IExtensibleDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        var copy = @this.ShallowCopy();
        copy.RemoveKeys(other);
        return copy;
    }
    public static IExtensibleDictionary<TKey, TValue> operator +(IExtensibleDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        var copy = @this.ShallowCopy();
        copy.Add(item);
        return copy;
    }
    public static IExtensibleDictionary<TKey, TValue> operator -(IExtensibleDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        var copy = @this.ShallowCopy();
        copy.RemoveKey(item);
        return copy;
    }
    #endregion Operators
}
