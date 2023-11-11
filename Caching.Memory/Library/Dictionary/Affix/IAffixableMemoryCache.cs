namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache with a morpheme attached to the key.
/// </summary>
public interface IAffixableMemoryCache<TKey, TValue>: IGenericMemoryCache<TKey, TValue>
{
}
