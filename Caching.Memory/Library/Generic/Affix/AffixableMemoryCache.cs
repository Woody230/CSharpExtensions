using System.Diagnostics.CodeAnalysis;

namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache with a morpheme attached to the key. 
/// </summary>
public abstract class AffixableMemoryCache<TValue> : IGenericMemoryCache<string, TValue>
{
    private readonly IGenericMemoryCache<string, TValue> _cache;

    public AffixableMemoryCache(IGenericMemoryCache<string, TValue> cache)
    {
        _cache = cache;
    }

    public IEnumerable<string> Keys => _cache.Keys;

    public void Remove(string key)
    {
        var affixedKey = GetAffixedKey(key);
        _cache.Remove(affixedKey);
    }

    public void Set(string key, TValue value, IMemoryCacheEntryOptions options)
    {
        var affixedKey = GetAffixedKey(key);
        _cache.Set(affixedKey, value, options);
    }

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out TValue value)
    {
        var affixedKey = GetAffixedKey(key);
        return _cache.TryGetValue(affixedKey, out value);
    }

    /// <summary>
    /// Gets the affixed key associated with the <paramref name="key"/>.
    /// </summary>
    protected abstract string GetAffixedKey(string key);
}