using System.Diagnostics.CodeAnalysis;

namespace Woody230.Caching.Memory.Generic;

/// <summary>
/// Represents a memory cache with a morpheme attached to the key. 
/// </summary>
public abstract class AffixableMemoryCache<TValue>(IGenericMemoryCache<string, TValue> cache) : IAffixableMemoryCache<TValue>
{
    private readonly IGenericMemoryCache<string, TValue> _cache = cache;

    /// <inheritdoc/>
    public IEnumerable<string> AffixedKeys => _cache.Keys;

    /// <inheritdoc/>
    public IEnumerable<string> UnaffixedKeys => _cache.Keys.Select(GetUnaffixedKey);

    /// <inheritdoc/>
    public void Remove(string key)
    {
        var affixedKey = GetAffixedKey(key);
        _cache.Remove(affixedKey);
    }

    /// <inheritdoc/>
    public void Set(string key, TValue value, IGenericMemoryCacheEntryOptions options)
    {
        var affixedKey = GetAffixedKey(key);
        _cache.Set(affixedKey, value, options);
    }

    /// <inheritdoc/>
    public bool TryGetValue(string key, [MaybeNullWhen(false)] out TValue value)
    {
        var affixedKey = GetAffixedKey(key);
        return _cache.TryGetValue(affixedKey, out value);
    }

    /// <summary>
    /// Gets the <paramref name="key"/> with the affix.
    /// </summary>
    protected abstract string GetAffixedKey(string key);

    /// <summary>
    /// Gets the <paramref name="key"/> without the affix.
    /// </summary>
    protected abstract string GetUnaffixedKey(string key);
}