namespace Woody230.Caching.Memory.Generic;

/// <inheritdoc/>
public sealed class StringifiedMemoryCache<TKey, TValue> : StringifiableMemoryCache<TKey, TValue> where TKey: notnull
{
    private readonly StringifyKey<TKey> _stringify;

    public StringifiedMemoryCache(IGenericMemoryCache<string, TValue> cache, StringifyKey<TKey> stringify): base(cache)
    {
        _stringify = stringify;
    }

    /// <summary>
    /// Uses <see cref="TKey.ToString"/> to stringify the key.
    /// </summary>
    public StringifiedMemoryCache(IGenericMemoryCache<string, TValue> cache): this(cache, (key) => key?.ToString() ?? string.Empty)
    {
    }

    protected override string Stringify(TKey key) => _stringify(key);
}
