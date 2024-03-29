﻿namespace Woody230.Collections.Generic;

/// <summary>
/// Represents extensions for a <see cref="IDictionary{TKey, TValue}"/>.
/// </summary>
public static class DictionaryExtensions
{
    #if NET6_0
    /// <summary>
    /// Converts <paramref name="this"/> collection of tuples to a dictionary.
    /// </summary>
    public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey, TValue)> @this) where TKey : notnull
    {
        return @this.ToDictionary(pair => pair.Item1, pair => pair.Item2);
    }
    #endif

    /// <summary>
    /// Removes the key value pairs associated with each of the keys from the <paramref name="other"/> collection in <paramref name="this"/> collection.
    /// </summary>
    public static void RemoveKeys<TKey, TValue>(this IDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        foreach (var pair in other)
        {
            @this.RemoveKey(pair);
        }
    }

    /// <summary>
    /// Removes the key value pairs associated with each of the <paramref name="keys"/> in <paramref name="this"/> collection.
    /// </summary>
    public static void RemoveKeys<TKey, TValue>(this IDictionary<TKey, TValue> @this, IEnumerable<TKey> keys)
    {
        foreach (var key in keys)
        {
            @this.Remove(key);
        }
    }

    /// <summary>
    /// Removes the key value pair associated with the key of the <paramref name="pair"/> in <paramref name="this"/> collection.
    /// </summary>
    public static void RemoveKey<TKey, TValue>(this IDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> pair)
    {
        @this.Remove(pair.Key);
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
