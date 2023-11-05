using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="IDictionary{TKey, TValue}"/> that does NOT throw an exception when adding duplicate keys.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
public sealed class LenientDictionary<TKey, TValue>: ExtensibleDictionary<TKey, TValue> where TKey: notnull
{
    public LenientDictionary() : base(new Dictionary<TKey, TValue>())
    {
    }

    public LenientDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
    {
    }

    /// <summary>
    /// Adds the value if the key does not exist, or replaces the existing value when the key exists.
    /// </summary>
    public override void Add(KeyValuePair<TKey, TValue> item)
    {
        try
        {
            this.Put(item);
        }
        catch (KeyNotFoundException)
        {
            // With a typical dictionary indexing won't produce a key not found exception.
        }
    }

    #region Operators
    public static LenientDictionary<TKey, TValue> operator +(LenientDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        @this.AddAll(other);
        return @this;
    }
    public static LenientDictionary<TKey, TValue> operator -(LenientDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        @this.RemoveAll(other);
        return @this;
    }
    public static LenientDictionary<TKey, TValue> operator +(LenientDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        @this.Add(item);
        return @this;
    }
    public static LenientDictionary<TKey, TValue> operator -(LenientDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        @this.Remove(item);
        return @this;
    }
    #endregion Operators
}
