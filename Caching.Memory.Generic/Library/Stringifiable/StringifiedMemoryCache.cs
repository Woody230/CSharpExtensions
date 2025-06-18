namespace Woody230.Caching.Memory.Generic;

/// <inheritdoc/>
public sealed class StringifiedMemoryCache<TKey, TValue>(IGenericMemoryCache<string, TValue> cache, StringifyKey<TKey> stringify) : StringifiableMemoryCache<TKey, TValue>(cache) where TKey: notnull
{
    private readonly StringifyKey<TKey> _stringify = stringify;

    /// <summary>
    /// Uses <see cref="TKey.ToString"/> to stringify the key.
    /// </summary>
    public StringifiedMemoryCache(IGenericMemoryCache<string, TValue> cache): this(cache, (key) => key?.ToString() ?? string.Empty)
    {
    }

    protected override string Stringify(TKey key) => _stringify(key);
}
