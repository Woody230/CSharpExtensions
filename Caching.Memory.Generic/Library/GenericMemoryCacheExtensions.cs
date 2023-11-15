namespace Woody230.Caching.Memory.Generic;

/// <summary>
/// Represents extensions for a <see cref="IGenericMemoryCache{TKey, TValue}"/>
/// </summary>
public static class GenericMemoryCacheExtensions
{
    /// <summary>
    /// Removes all keys in the cache.
    /// </summary>
    public static void Clear<TKey, TValue>(this IGenericMemoryCache<TKey, TValue> @this) where TKey : notnull
    {
        foreach (var key in @this.Keys)
        {
            @this.Remove(key);
        }
    }

    /// <summary>
    /// Sets the <paramref name="value"/> associated with the <paramref name="key"/> with the default <see cref="MemoryCacheEntryOptions"/>.
    /// </summary>
    public static void Set<TKey, TValue>(this IGenericMemoryCache<TKey, TValue> @this, TKey key, TValue value) where TKey : notnull
    {
        @this.Set(key, value, new GenericMemoryCacheEntryOptions());
    }

    /// <summary>
    /// Gets the value associated with the <paramref name="key"/>, otherwise uses the value from <paramref name="createValue"/> and stores it in the cache with the given <paramref name="options"/>.
    /// </summary>
    public static TValue GetOrCreate<TKey, TValue>(this IGenericMemoryCache<TKey, TValue> @this, TKey key, IGenericMemoryCacheEntryOptions options, Func<TValue> createValue) where TKey : notnull
    {
        if (@this.TryGetValue(key, out var value))
        {
            return value;
        }

        value = createValue();
        @this.Set(key, value, options);
        return value;
    }

    /// <summary>
    /// Gets the value associated with the <paramref name="key"/>, otherwise uses the value from <paramref name="createValue"/> and stores it in the cache with the default <see cref="MemoryCacheEntryOptions"/>.
    /// </summary>
    public static TValue GetOrCreate<TKey, TValue>(this IGenericMemoryCache<TKey, TValue> @this, TKey key, Func<TValue> createValue) where TKey : notnull
    {
        return GetOrCreate(@this, key, new GenericMemoryCacheEntryOptions(), createValue);
    }
}
