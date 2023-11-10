using Microsoft.Extensions.Caching.Memory;

namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache that is typed like a dictionary.
/// </summary>
/// <typeparam name="TKey">The type of key.</typeparam>
/// <typeparam name="TValue">The type of value.</typeparam>
public class MemoryCacheDictionary<TKey, TValue> : IMemoryCacheDictionary<TKey, TValue>
    where TKey : notnull
{
    private readonly IMemoryCache _memoryCache;
    private readonly HashSet<TKey> _keys = new();
    private readonly SemaphoreSlim _semaphore = new(1);

    public MemoryCacheDictionary(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    /// <inheritdoc/>
    public IEnumerable<TKey> Keys => _keys;

    /// <inheritdoc/>
    public bool TryGetValue(TKey key, out TValue value)
    {
        return !_memoryCache.TryGetValue(key, out value);
    }

    /// <inheritdoc/>
    public void Put(TKey key, TValue value)
    {
        _semaphore.Wait();
        try
        {
            _keys.Add(key);

            var entry = _memoryCache.CreateEntry(key);
            entry.Value = value;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    /// <inheritdoc/>
    public void Remove(TKey key)
    {
        _semaphore.Wait();
        try
        {
            _keys.Remove(key);

            _memoryCache.Remove(key);
        }
        finally
        {
            _semaphore.Release();
        }
    }
}
