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
    public static void Put<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, TValue value) 
    {
        @this[key] = value;
    }

    /// <summary>
    /// Adds the value if the key does not exist, or replaces the existing value when the key exists.
    /// </summary>
    public static void Put<TKey, TValue>(this IDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> pair)
    {
        @this.Put(pair.Key, pair.Value);
    }

    /// <summary>
    /// Adds the values from the <paramref name="other"/> collection if the keys do not exist, or replaces the existing values when the key exists in <paramref name="this"/> collection.
    /// </summary>
    public static void PutAll<TKey, TValue>(this IDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        foreach (var pair in other)
        {
            @this.Put(pair);
        }
    }

    /// <summary>
    /// Adds the values from the <paramref name="other"/> collection if the keys do not exist, or replaces the existing values when the key exists in <paramref name="this"/> collection.
    /// </summary>
    public static void PutAll<TKey, TValue>(this IDictionary<TKey, TValue> @this, params KeyValuePair<TKey, TValue>[] other)
    {
        @this.PutAll(other.ToList());
    }

    /// <summary>
    /// Selects the keys from <paramref name="this"/> collection according to the <paramref name="keySelector"/>. The values remain the same.
    /// </summary>
    public static IDictionary<TNewKey, TValue> SelectKeys<TKey, TValue, TNewKey>(this IDictionary<TKey, TValue> @this, Func<TKey, TNewKey> keySelector) where TKey : notnull where TNewKey : notnull
    {
        return @this.ToDictionary(pair => keySelector(pair.Key), pair => pair.Value);
    }

    /// <summary>
    /// Selects the values from <paramref name="this"/> collection according to the <paramref name="valueSelector"/>. The keys remain the same.
    /// </summary>
    public static IDictionary<TKey, TNewValue> SelectValues<TKey, TValue, TNewValue>(this IDictionary<TKey, TValue> @this, Func<TValue, TNewValue> valueSelector) where TKey : notnull
    {
        return @this.ToDictionary(pair => pair.Key, pair => valueSelector(pair.Value));
    }
}
