namespace Woody230.Caching.Memory.Generic;

/// <summary>
/// Represents a memory cache with a prefix attached to the key.
/// </summary>
public sealed class PrefixedMemoryCache<TValue>(IGenericMemoryCache<string, TValue> cache, string prefix) : AffixableMemoryCache<TValue>(cache)
{
    private readonly string _prefix = prefix;

    public PrefixedMemoryCache(IGenericMemoryCache<string, TValue> cache) : this(cache, typeof(TValue).Name + "-")
    {
    }

    protected override string GetAffixedKey(string key) => _prefix + key;
    protected override string GetUnaffixedKey(string key) => key.Substring(_prefix.Length);
}
