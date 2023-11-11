namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache with a morpheme attached to the key.
/// </summary>
public interface IAffixableMemoryCache<TValue>: IGenericMemoryCache<string, TValue>
{
}
