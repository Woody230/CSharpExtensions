using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using Moq;

namespace Woody230.Caching.Memory.Tests.Unit;

/// <summary>
/// Represents tests for the <see cref="StringifiedMemoryCache{TKey, TValue}"/>
/// </summary>
public class StringifiedMemoryCacheTests
{
    private enum Flag
    {
        First,
        Second,
        Third
    }

    private readonly IMemoryCache _memoryCache;
    private readonly IGenericMemoryCache<string, int> _genericCache;
    private readonly StringifiedMemoryCache<Flag, int> _stringifiedCache;

    public StringifiedMemoryCacheTests()
    {
        _memoryCache = new MemoryCache(new MemoryCacheOptions());
        _genericCache = new GenericMemoryCache<string, int>(_memoryCache);
        _stringifiedCache = new StringifiedMemoryCache<Flag, int>(_genericCache);
    }

    [Fact]
    public void Add_DoesNotExist()
    {
        // Act
        _stringifiedCache.Set(Flag.Second, 99, new MemoryCacheEntryOptions());

        // Assert
        _memoryCache.TryGetValue("Second", out object objectValue).Should().BeTrue();
        objectValue.Should().Be(99);

        _stringifiedCache.TryGetValue(Flag.Second, out int intValue).Should().BeTrue();
        intValue.Should().Be(99);

        _stringifiedCache.Keys.Should().BeEquivalentTo(new List<Flag>() { Flag.Second });
    }

    [Fact]
    public void Add_SetsEntryOptions()
    {
        // Arrange
        var mockMemoryCache = new Mock<IMemoryCache>();

        var mockCacheEntry = new Mock<ICacheEntry>();
        var mockCacheEntryTokens = new List<IChangeToken>();
        mockCacheEntry.SetupGet(entry => entry.ExpirationTokens).Returns(mockCacheEntryTokens);

        var mockChangeToken = new Mock<IChangeToken>();

        var genericCache = new GenericMemoryCache<string, int>(mockMemoryCache.Object);
        var stringifiedCache = new StringifiedMemoryCache<Flag, int>(genericCache);

        mockMemoryCache.Setup(cache => cache.CreateEntry("Second")).Returns(mockCacheEntry.Object);

        // Act
        stringifiedCache.Set(Flag.Second, 99, new MemoryCacheEntryOptions()
        {
            AbsoluteExpiration = new DateTime(2015, 5, 6),
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
            ExpirationTokens = new List<IChangeToken>() { mockChangeToken.Object },
            Priority = CacheItemPriority.NeverRemove,
            Size = 1234,
            SlidingExpiration = TimeSpan.FromMinutes(30)
        });

        // Assert
        mockMemoryCache.Verify(cache => cache.CreateEntry("Second"), Times.Once);

        mockCacheEntry.VerifySet(entry => entry.AbsoluteExpiration = new DateTime(2015, 5, 6));
        mockCacheEntry.VerifySet(entry => entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1));
        mockCacheEntryTokens.Should().BeEquivalentTo(new List<IChangeToken>() { mockChangeToken.Object });
        mockCacheEntry.VerifySet(entry => entry.Priority = CacheItemPriority.NeverRemove);
        mockCacheEntry.VerifySet(entry => entry.Size = 1234);
        mockCacheEntry.VerifySet(entry => entry.SlidingExpiration = TimeSpan.FromMinutes(30));
    }

    [Fact]
    public void Add_Exists()
    {
        // Arrange
        _stringifiedCache.Set(Flag.Second, 45, new MemoryCacheEntryOptions());

        // Act
        _stringifiedCache.Set(Flag.Second, 99, new MemoryCacheEntryOptions());

        // Assert
        _memoryCache.TryGetValue("Second", out object objectValue).Should().BeTrue();
        objectValue.Should().Be(99);

        _stringifiedCache.TryGetValue(Flag.Second, out int intValue).Should().BeTrue();
        intValue.Should().Be(99);

        _stringifiedCache.Keys.Should().BeEquivalentTo(new List<Flag>() { Flag.Second });
    }

    [Fact]
    public void Remove_DoesNotExist()
    {
        // Arrange
        _stringifiedCache.Set(Flag.Third, 99, new MemoryCacheEntryOptions());

        // Act
        _stringifiedCache.Remove(Flag.Second);

        // Assert
        _stringifiedCache.Keys.Should().BeEquivalentTo(new List<Flag>() { Flag.Third });
    }

    [Fact]
    public void Remove_Exists()
    {
        // Arrange
        _stringifiedCache.Set(Flag.Second, 123, new MemoryCacheEntryOptions());

        // Act
        _stringifiedCache.Remove(Flag.Second);

        // Assert
        _stringifiedCache.Keys.Should().BeEmpty();
    }

    [Fact]
    public void StringifyKey()
    {
        // Arrange
        var stringifiedCache = new StringifiedMemoryCache<Flag, int>(_genericCache, (flag) => flag.ToString() + "-" + (int)flag);

        // Act
        stringifiedCache.Set(Flag.Second, 99, new MemoryCacheEntryOptions());

        // Assert
        _memoryCache.TryGetValue("Second-1", out object objectValue).Should().BeTrue();
        objectValue.Should().Be(99);

        stringifiedCache.TryGetValue(Flag.Second, out int intValue).Should().BeTrue();
        intValue.Should().Be(99);

        stringifiedCache.Keys.Should().BeEquivalentTo(new List<Flag>() { Flag.Second });
    }
}

