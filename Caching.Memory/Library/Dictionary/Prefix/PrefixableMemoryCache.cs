using System.Diagnostics.CodeAnalysis;

namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache with a prefixed key specific to the type of key.
/// </summary>
public abstract class PrefixableMemoryCache<TKey, TValue>: IPrefixableMemoryCache<TKey, TValue> where TKey : notnull
{
    private readonly IGenericMemoryCache<string, TValue> _cache;
    private readonly HashSet<TKey> _keys = new();
    private readonly SemaphoreSlim _semaphore = new(1);

    public PrefixableMemoryCache(IGenericMemoryCache<string, TValue> cache)
    {
        _cache = cache;
    }

    /// <inheritdoc/>
    public IEnumerable<TKey> Keys => _keys;

    /// <inheritdoc/>
    public void Remove(TKey key)
    {
        var prefixedKey = GetPrefixedKey(key);

        _semaphore.Wait();
        try
        {
            _keys.Add(key);
            _cache.Remove(prefixedKey);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    /// <inheritdoc/>
    public void Set(TKey key, TValue value, IMemoryCacheEntryOptions options)
    {
        var prefixedKey = GetPrefixedKey(key);
        _cache.Set(prefixedKey, value, options);
    }

    /// <inheritdoc/>
    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        var prefixedKey = GetPrefixedKey(key);
        return _cache.TryGetValue(prefixedKey, out value);
    }

    /// <summary>
    /// Gets the prefixed string key associated with the <paramref name="key"/>.
    /// </summary>
    protected abstract string GetPrefixedKey(TKey key);
}

/// <summary>
/// Represents a memory cache with a prefixed key. 
/// </summary>
public abstract class PrefixableMemoryCache<TValue> : IPrefixableMemoryCache<string, TValue>
{
    private readonly IGenericMemoryCache<string, TValue> _cache;

    public PrefixableMemoryCache(IGenericMemoryCache<string, TValue> cache)
    {
        _cache = cache;
    }

    public IEnumerable<string> Keys => _cache.Keys.Select(GetPrefixedKey);

    public void Remove(string key)
    {
        var prefixedKey = GetPrefixedKey(key);
        _cache.Remove(prefixedKey);
    }

    public void Set(string key, TValue value, IMemoryCacheEntryOptions options)
    {
        var prefixedKey = GetPrefixedKey(key);
        _cache.Set(prefixedKey, value, options);
    }

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out TValue value)
    {
        var prefixedKey = GetPrefixedKey(key);
        return _cache.TryGetValue(prefixedKey, out value);
    }

    /// <summary>
    /// Gets the prefixed key associated with the <paramref name="key"/>.
    /// </summary>
    protected abstract string GetPrefixedKey(string key);
}