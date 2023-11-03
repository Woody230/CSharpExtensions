using System;
using System.Collections.Generic;
using System.Linq;

namespace Woody230.Collections.Generic;

/// <summary>
/// Represents extensions for a <see cref="IDictionary{TKey, TValue}"/>.
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    /// Converts <paramref name="this"/> collection of tuples to a dictionary.
    /// </summary>
    public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey, TValue)> @this) where TKey : notnull
    {
        return @this.ToDictionary(pair => pair.Item1, pair => pair.Item2);
    }

    /// <summary>
    /// Adds the <paramref name="value"/> if the <paramref name="key"/> does not exist, or replaces the existing value when the <paramref name="key"/> exists.
    /// </summary>
    public static TDictionary Put<TKey, TValue, TDictionary>(this TDictionary @this, TKey key, TValue value) 
        where TDictionary : IDictionary<TKey, TValue>
    {
        @this[key] = value;
        return @this;
    }

    /// <summary>
    /// Adds the value if the key does not exist, or replaces the existing value when the key exists.
    /// </summary>
    public static TDictionary Put<TKey, TValue, TDictionary>(this TDictionary @this, KeyValuePair<TKey, TValue> pair)
        where TDictionary : IDictionary<TKey, TValue>
    {
        return @this.Put(pair.Key, pair.Value);
    }

    /// <summary>
    /// Adds the values from the <paramref name="other"/> collection if the keys do not exist, or replaces the existing values when the key exists in <paramref name="this"/> collection.
    /// </summary>
    public static TDictionary PutAll<TKey, TValue, TDictionary>(this TDictionary @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
        where TDictionary : IDictionary<TKey, TValue>
    {
        foreach (var pair in other)
        {
            @this.Put(pair);
        }

        return @this;
    }

    /// <summary>
    /// Adds the values from the <paramref name="other"/> collection if the keys do not exist, or replaces the existing values when the key exists in <paramref name="this"/> collection.
    /// </summary>
    public static TDictionary PutAll<TKey, TValue, TDictionary>(this TDictionary @this, KeyValuePair<TKey, TValue>[] other)
        where TDictionary : IDictionary<TKey, TValue>
        where TKey : notnull
    {
        foreach (var pair in other)
        {
            @this.Put(pair);
        }

        return @this;
    }

    /// <summary>
    /// Selects the keys from <paramref name="this"/> collection according to the <paramref name="keySelector"/>. The values remain the same.
    /// </summary>
    public static IDictionary<TNewKey, TValue> SelectKeys<TKey, TValue, TNewKey>(this IDictionary<TKey, TValue> @this, Func<KeyValuePair<TKey, TValue>, TNewKey> keySelector) where TKey : notnull where TNewKey : notnull
    {
        return @this.ToDictionary(pair => keySelector(pair), pair => pair.Value);
    }

    /// <summary>
    /// Selects the keys from <paramref name="this"/> collection according to the <paramref name="keySelector"/>. The values remain the same.
    /// </summary>
    public static IDictionary<TNewKey, TValue> SelectKeys<TKey, TValue, TNewKey>(this IDictionary<TKey, TValue> @this, Func<TKey, TNewKey> keySelector) where TKey : notnull where TNewKey : notnull
    {
        return @this.ToDictionary(pair => keySelector(pair.Key), pair => pair.Value);
    }

    /// <summary>
    /// Selects the keys from <paramref name="this"/> collection according to the <paramref name="keySelector"/>. The values remain the same.
    /// </summary>
    public static IDictionary<TNewKey, TValue> SelectKeys<TKey, TValue, TNewKey>(this IDictionary<TKey, TValue> @this, Func<TValue, TNewKey> keySelector) where TKey : notnull where TNewKey : notnull
    {
        return @this.ToDictionary(pair => keySelector(pair.Value), pair => pair.Value);
    }

    /// <summary>
    /// Selects the values from <paramref name="this"/> collection according to the <paramref name="valueSelector"/>. The keys remain the same.
    /// </summary>
    public static IDictionary<TKey, TNewValue> SelectValues<TKey, TValue, TNewValue>(this IDictionary<TKey, TValue> @this, Func<KeyValuePair<TKey, TValue>, TNewValue> valueSelector) where TKey : notnull
    {
        return @this.ToDictionary(pair => pair.Key, pair => valueSelector(pair));
    }

    /// <summary>
    /// Selects the values from <paramref name="this"/> collection according to the <paramref name="valueSelector"/>. The keys remain the same.
    /// </summary>
    public static IDictionary<TKey, TNewValue> SelectValues<TKey, TValue, TNewValue>(this IDictionary<TKey, TValue> @this, Func<TKey, TNewValue> valueSelector) where TKey : notnull
    {
        return @this.ToDictionary(pair => pair.Key, pair => valueSelector(pair.Key));
    }

    /// <summary>
    /// Selects the values from <paramref name="this"/> collection according to the <paramref name="valueSelector"/>. The keys remain the same.
    /// </summary>
    public static IDictionary<TKey, TNewValue> SelectValues<TKey, TValue, TNewValue>(this IDictionary<TKey, TValue> @this, Func<TValue, TNewValue> valueSelector) where TKey : notnull
    {
        return @this.ToDictionary(pair => pair.Key, pair => valueSelector(pair.Value));
    }
}
