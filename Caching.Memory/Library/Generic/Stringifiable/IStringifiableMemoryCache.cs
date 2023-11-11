namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache where the key is converted to a string.
/// </summary>
public interface IStringifiableMemoryCache<TKey, TValue>: IGenericMemoryCache<TKey, TValue> where TKey: notnull
{
}
