using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Woody230.Caching.Memory.Generic;

/// <summary>
/// Represents the cache options applied to an entry of the <see cref="IMemoryCache"/> instance.
/// </summary>
public record GenericMemoryCacheEntryOptions : IGenericMemoryCacheEntryOptions
{
    public DateTimeOffset? AbsoluteExpiration { get; init; }
    public TimeSpan? AbsoluteExpirationRelativeToNow { get; init; }
    public TimeSpan? SlidingExpiration { get; init; }
    public IEnumerable<IChangeToken> ExpirationTokens { get; init; } = Enumerable.Empty<IChangeToken>();
    public CacheItemPriority Priority { get; init; } = CacheItemPriority.Normal;
    public long? Size { get; init; }
}
