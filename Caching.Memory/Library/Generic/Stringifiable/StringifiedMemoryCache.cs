using System.Diagnostics.CodeAnalysis;

namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache where the key is converted to a string.
/// </summary>
public sealed class StringifiedMemoryCache<TKey, TValue> : IGenericMemoryCache<TKey, TValue> where TKey: notnull
{
    private readonly IGenericMemoryCache<string, TValue> _cache;
    private readonly HashSet<TKey> _keys = new();
    private readonly SemaphoreSlim _semaphore = new(1);
    private readonly StringifyKey<TKey> _stringify;

    public StringifiedMemoryCache(IGenericMemoryCache<string, TValue> cache, StringifyKey<TKey> stringify)
    {
        _cache = cache;
        _stringify = stringify;
    }

    public StringifiedMemoryCache(IGenericMemoryCache<string, TValue> cache): this(cache, (key) => key?.ToString() ?? string.Empty)
    {
    }

    /// <inheritdoc/>
    public IEnumerable<TKey> Keys => _keys;

    /// <inheritdoc/>
    public void Remove(TKey key)
    {
        var stringifiedKey = _stringify(key);

        _semaphore.Wait();
        try
        {
            _keys.Add(key);
            _cache.Remove(stringifiedKey);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    /// <inheritdoc/>
    public void Set(TKey key, TValue value, IMemoryCacheEntryOptions options)
    {
        var stringifiedKey = _stringify(key);
        _cache.Set(stringifiedKey, value, options);
    }

    /// <inheritdoc/>
    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        var stringifiedKey = _stringify(key);
        return _cache.TryGetValue(stringifiedKey, out value);
    }
}
