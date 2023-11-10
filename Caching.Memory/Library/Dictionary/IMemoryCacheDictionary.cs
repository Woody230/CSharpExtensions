using System.Diagnostics.CodeAnalysis;

namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache that is typed like a dictionary.
/// </summary>
/// <typeparam name="TKey">The type of key.</typeparam>
/// <typeparam name="TValue">The type of value.</typeparam>
public interface IMemoryCacheDictionary<TKey, TValue>
{
    /// <summary>
    /// The keys in the cache.
    /// </summary>
    public IEnumerable<TKey> Keys { get; }

    /// <summary>
    /// Adds or replaces the <paramref name="key"/> <paramref name="value"/> entry in the cache.
    /// </summary>
    public void Set(TKey key, TValue value);

    /// <summary>
    /// Removes the value associated with the <paramref name="key"/> if it exists in the cache.
    /// </summary>
    public void Remove(TKey key);

    /// <summary>
    /// Gets the <paramref name="value"/> associated with the <paramref name="key"/> if it exists in the cache.
    /// </summary>
    /// <returns>True if the key was found.</returns>
    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value);
}
