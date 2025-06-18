using System.Diagnostics.CodeAnalysis;

namespace Woody230.Caching.Memory.Generic;

/// <summary>
/// Represents a memory cache where the key is converted to a string.
/// </summary>
public abstract class StringifiableMemoryCache<TKey, TValue>(IGenericMemoryCache<string, TValue> cache) : IGenericMemoryCache<TKey, TValue> where TKey : notnull
{
    private readonly IGenericMemoryCache<string, TValue> _cache = cache;
    private readonly HashSet<TKey> _keys = [];
    private readonly SemaphoreSlim _semaphore = new(1);

    /// <inheritdoc/>
    public IEnumerable<TKey> Keys => _keys;

    /// <inheritdoc/>
    public void Remove(TKey key)
    {
        var stringifiedKey = Stringify(key);

        _semaphore.Wait();
        try
        {
            _keys.Remove(key);

            _cache.Remove(stringifiedKey);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    /// <inheritdoc/>
    public void Set(TKey key, TValue value, IGenericMemoryCacheEntryOptions options)
    {
        var stringifiedKey = Stringify(key);

        _semaphore.Wait();
        try
        {
            _keys.Add(key);

            _cache.Set(stringifiedKey, value, options);
        } 
        finally
        {
            _semaphore.Release();
        }
    }

    /// <inheritdoc/>
    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        var stringifiedKey = Stringify(key);
        return _cache.TryGetValue(stringifiedKey, out value);
    }

    /// <summary>
    /// Converts the key to a string.
    /// </summary>
    protected abstract string Stringify(TKey key);
}
