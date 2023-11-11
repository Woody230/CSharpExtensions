using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics.CodeAnalysis;

namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache that is typed.
/// </summary>
/// <typeparam name="TKey">The type of key.</typeparam>
/// <typeparam name="TValue">The type of value.</typeparam>
public sealed class GenericMemoryCache<TKey, TValue> : IGenericMemoryCache<TKey, TValue> where TKey : notnull
{
    private readonly IMemoryCache _memoryCache;
    private readonly HashSet<TKey> _keys = new();
    private readonly SemaphoreSlim _semaphore = new(1);

    public GenericMemoryCache(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    /// <inheritdoc/>
    public IEnumerable<TKey> Keys => _keys;

    /// <inheritdoc/>
    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        return _memoryCache.TryGetValue(key, out value);
    }

    /// <inheritdoc/>
    public void Set(TKey key, TValue value, IMemoryCacheEntryOptions options)
    {
        _semaphore.Wait();
        try
        {
            _keys.Add(key);

            _memoryCache.Set(key, value, Convert(options));
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

    private static Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions Convert(IMemoryCacheEntryOptions options)
    {

        var microsoftOptions = new Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions()
        {
            AbsoluteExpiration = options.AbsoluteExpiration,
            AbsoluteExpirationRelativeToNow = options.AbsoluteExpirationRelativeToNow,
            SlidingExpiration = options.SlidingExpiration,
            Priority = options.Priority,
            Size = options.Size,
        };
        
        foreach (var expirationToken in options.ExpirationTokens)
        {
            microsoftOptions.AddExpirationToken(expirationToken);
        }

        return microsoftOptions;
    }
}
