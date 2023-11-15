namespace Woody230.Caching.Memory.Generic;

/// <summary>
/// Represents a memory cache with a morpheme attached to the key. 
/// </summary>
public interface IAffixableMemoryCache<TValue>: IGenericMemoryCache<string, TValue>
{
    /// <summary>
    /// The keys in the cache with the morpheme attached.
    /// </summary>
    public IEnumerable<string> AffixedKeys { get; }

    /// <summary>
    /// The keys in the cache without the morpheme attached.
    /// </summary>
    public IEnumerable<string> UnaffixedKeys { get; }

    IEnumerable<string> IGenericMemoryCache<string, TValue>.Keys => AffixedKeys;
}
