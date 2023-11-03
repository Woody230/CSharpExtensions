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
