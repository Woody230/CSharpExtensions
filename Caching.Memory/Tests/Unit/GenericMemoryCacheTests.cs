using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using Moq;

namespace Woody230.Caching.Memory.Tests.Unit;

/// <summary>
/// Represents tests for the <see cref="GenericMemoryCacheTests{TKey, TValue}"/>
/// </summary>
public class GenericMemoryCacheTests
{
    private readonly IMemoryCache _memoryCache;
    private readonly IGenericMemoryCache<string, int> _genericCache;

    public GenericMemoryCacheTests()
    {
        _memoryCache = new MemoryCache(new MemoryCacheOptions());
        _genericCache = new GenericMemoryCache<string, int>(_memoryCache);
    }

    [Fact]
    public void Add_DoesNotExist()
    {
        // Act
        _genericCache.Set("Foo", 99, new MemoryCacheEntryOptions());

        // Assert
        _memoryCache.TryGetValue("Foo", out object objectValue).Should().BeTrue();
        objectValue.Should().Be(99);

        _genericCache.TryGetValue("Foo", out int intValue).Should().BeTrue();
        intValue.Should().Be(99);

        _genericCache.Keys.Should().BeEquivalentTo(new List<string>() { "Foo" });
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

        mockMemoryCache.Setup(cache => cache.CreateEntry("Foo")).Returns(mockCacheEntry.Object);

        // Act
        genericCache.Set("Foo", 99, new MemoryCacheEntryOptions()
        {
            AbsoluteExpiration = new DateTime(2015, 5, 6),
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
            ExpirationTokens = new List<IChangeToken>() { mockChangeToken.Object },
            Priority = CacheItemPriority.NeverRemove,
            Size = 1234,
            SlidingExpiration = TimeSpan.FromMinutes(30)
        });

        // Assert
        mockMemoryCache.Verify(cache => cache.CreateEntry("Foo"), Times.Once);

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
        _genericCache.Set("Foo", 45, new MemoryCacheEntryOptions());

        // Act
        _genericCache.Set("Foo", 99, new MemoryCacheEntryOptions());

        // Assert
        _memoryCache.TryGetValue("Foo", out object objectValue).Should().BeTrue();
        objectValue.Should().Be(99);

        _genericCache.TryGetValue("Foo", out int intValue).Should().BeTrue();
        intValue.Should().Be(99);

        _genericCache.Keys.Should().BeEquivalentTo(new List<string>() { "Foo" });
    }

    [Fact]
    public void Remove_DoesNotExist()
    {
        // Arrange
        _genericCache.Set("Bar", 99, new MemoryCacheEntryOptions());

        // Act
        _genericCache.Remove("Foo");

        // Assert
        _genericCache.Keys.Should().BeEquivalentTo(new List<string>() { "Bar" });
    }

    [Fact]
    public void Remove_Exists()
    {
        // Arrange
        _genericCache.Set("Foo", 123, new MemoryCacheEntryOptions());

        // Act
        _genericCache.Remove("Foo");

        // Assert
        _genericCache.Keys.Should().BeEmpty();
    }
}
