namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache with a prefix attached to the key.
/// </summary>
public sealed class PrefixedMemoryCache<TKey, TValue> : AffixableMemoryCache<TKey, TValue> where TKey : notnull
{
    private readonly string _prefix;

    public PrefixedMemoryCache(IGenericMemoryCache<string, TValue> cache, string prefix) : base(cache)
    {
        _prefix = prefix;
    }

    public PrefixedMemoryCache(IGenericMemoryCache<string, TValue> cache) : this(cache, typeof(TValue).Name + "-")
    {
    }

    protected override string GetAffixedKey(TKey key) => _prefix + key;
}

/// <summary>
/// Represents a memory cache with a prefix attached to the key.
/// </summary>
public sealed class PrefixedMemoryCache<TValue> : PrefixableMemoryCache<TValue>
{
    private readonly string _prefix;

    public PrefixedMemoryCache(IGenericMemoryCache<string, TValue> cache, string prefix): base(cache)
    {
        _prefix = prefix;
    }

    public PrefixedMemoryCache(IGenericMemoryCache<string, TValue> cache) : this(cache, typeof(TValue).Name + "-")
    {
    }

    protected override string GetAffixedKey(string key) => _prefix + key;
}
