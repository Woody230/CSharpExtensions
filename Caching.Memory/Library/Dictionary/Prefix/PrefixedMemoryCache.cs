namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache with a constant
/// </summary>
public sealed class PrefixedMemoryCache<TKey, TValue> : PrefixableMemoryCache<TKey, TValue> where TKey : notnull
{
    private readonly string _prefix;

    public PrefixedMemoryCache(IGenericMemoryCache<string, TValue> cache, string prefix) : base(cache)
    {
        _prefix = prefix;
    }

    public PrefixedMemoryCache(IGenericMemoryCache<string, TValue> cache) : this(cache, typeof(TValue).Name)
    {
    }

    protected override string GetPrefixedKey(TKey key) => _prefix + key;
}

/// <inheritdoc/>
public sealed class PrefixedMemoryCache<TValue> : PrefixableMemoryCache<TValue>
{
    private readonly string _prefix;

    public PrefixedMemoryCache(IGenericMemoryCache<string, TValue> cache, string prefix): base(cache)
    {
        _prefix = prefix;
    }

    public PrefixedMemoryCache(IGenericMemoryCache<string, TValue> cache) : this(cache, typeof(TValue).Name)
    {
    }

    protected override string GetPrefixedKey(string key) => _prefix + key;
}
