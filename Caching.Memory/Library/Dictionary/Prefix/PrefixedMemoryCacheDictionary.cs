using System.Diagnostics.CodeAnalysis;

namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache with a prefixed key. 
/// </summary>
public class PrefixedMemoryCacheDictionary<TValue> : IPrefixedMemoryCacheDictionary<TValue>
{
    private readonly IMemoryCacheDictionary<string, TValue> _cache;
    private readonly string _prefix;

    public PrefixedMemoryCacheDictionary(IMemoryCacheDictionary<string, TValue> cache, string prefix)
    {
        _cache = cache;
        _prefix = prefix;
    }

    public IEnumerable<string> Keys => _cache.Keys.Select(PrefixedKey);

    public void Remove(string key)
    {
        _cache.Remove(PrefixedKey(key));
    }

    public void Set(string key, TValue value, IMemoryCacheEntryOptions options)
    {
        _cache.Set(PrefixedKey(key), value, options);
    }

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out TValue value)
    {
        return _cache.TryGetValue(PrefixedKey(key), out value);
    }

    private string PrefixedKey(string key) => _prefix + key;
}
