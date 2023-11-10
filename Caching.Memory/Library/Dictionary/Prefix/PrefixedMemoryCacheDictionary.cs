using System.Diagnostics.CodeAnalysis;

namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache with a prefixed key. 
/// </summary>
public sealed class PrefixedMemoryCacheDictionary<TValue> : IPrefixableMemoryCacheDictionary<string, TValue>
{
    private readonly IMemoryCacheDictionary<string, TValue> _cache;
    private readonly string _prefix;

    public PrefixedMemoryCacheDictionary(IMemoryCacheDictionary<string, TValue> cache, string prefix)
    {
        _cache = cache;
        _prefix = prefix;
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

    private string GetPrefixedKey(string key) => _prefix + key;
}
