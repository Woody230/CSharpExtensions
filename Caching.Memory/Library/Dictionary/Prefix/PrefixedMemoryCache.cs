namespace Woody230.Caching.Memory;

/// <inheritdoc/>
public sealed class PrefixedMemoryCache<TKey, TValue> : PrefixableMemoryCache<TKey, TValue>
{
    private readonly string _prefix;

    public PrefixedMemoryCache(IGenericMemoryCache<string, TValue> cache, string prefix) : base(cache)
    {
        _prefix = prefix;
    }

    public PrefixedMemoryCache(IGenericMemoryCache<string, TValue> cache) : this(cache, typeof(TValue).Name)
    {
    }

    protected override string GetPrefix(TKey key) => _prefix;
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

    protected override string GetPrefix(string key) => _prefix;
}
