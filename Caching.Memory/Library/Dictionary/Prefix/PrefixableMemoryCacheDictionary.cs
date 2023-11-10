﻿using System.Diagnostics.CodeAnalysis;

namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache with a prefixed key. 
/// </summary>
public abstract class PrefixableMemoryCacheDictionary<TKey, TValue>: IPrefixableMemoryCacheDictionary<TKey, TValue>
{
    private readonly IMemoryCacheDictionary<string, TValue> _cache;
    private readonly HashSet<TKey> _keys = new();
    private readonly SemaphoreSlim _semaphore = new(1);

    public PrefixableMemoryCacheDictionary(IMemoryCacheDictionary<string, TValue> cache)
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
    /// Gets the prefix associated with the <paramref name="key"/>.
    /// </summary>
    protected abstract string GetPrefix(TKey key);

    private string GetPrefixedKey(TKey key) => GetPrefix(key) + key;
}
