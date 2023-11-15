using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Woody230.Caching.Memory.Generic;

/// <summary>
/// Represents the cache options applied to an entry of the <see cref="IMemoryCache"/> instance.
/// </summary>
public interface IGenericMemoryCacheEntryOptions
{
    /// <summary>
    /// The absolute expiration date for the cache entry.
    /// </summary>
    public DateTimeOffset? AbsoluteExpiration { get; init; }

    /// <summary>
    /// An absolute expiration time, relative to now.
    /// </summary>
    public TimeSpan? AbsoluteExpirationRelativeToNow { get; init; }

    /// <summary>
    /// How long a cache entry can be inactive (e.g. not accessed) before it will be removed.
    /// This will not extend the entry lifetime beyond the absolute expiration (if set).
    /// </summary>
    public TimeSpan? SlidingExpiration { get; init; }

    /// <summary>
    /// The <see cref="IChangeToken"/> instances which cause the cache entry to expire.
    /// </summary>
    public IEnumerable<IChangeToken> ExpirationTokens { get; init; }

    // NOTE does not include a collection of PostEvictionCallbackRegistration

    /// <summary>
    /// The priority for keeping the cache entry in the cache during a
    /// memory pressure triggered cleanup.
    /// </summary>
    public CacheItemPriority Priority { get; init; }

    /// <summary>
    /// The size of the cache entry value.
    /// </summary>
    public long? Size { get; init; }
}
