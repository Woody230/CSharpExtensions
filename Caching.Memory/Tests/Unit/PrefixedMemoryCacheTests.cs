using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Woody230.Caching.Memory.Tests.Unit;

/// <summary>
/// Represents tests for the <see cref="PrefixedMemoryCache{TValue}"/>
/// </summary>
public class PrefixedMemoryCacheTests
{
    private readonly IMemoryCache _memoryCache;
    private readonly IGenericMemoryCache<string, int> _genericCache;
    private readonly PrefixedMemoryCache<int> _prefixedCache;
    private readonly string _prefix = "PREFIX-";

    public PrefixedMemoryCacheTests()
    {
        _memoryCache = new MemoryCache(new MemoryCacheOptions());
        _genericCache = new GenericMemoryCache<string, int>(_memoryCache);
        _prefixedCache = new PrefixedMemoryCache<int>(_genericCache, _prefix);
    }

    [Fact]
    public void Add_DoesNotExist()
    {
        // Act
        _prefixedCache.Set("Foo", 99, new MemoryCacheEntryOptions());

        // Assert
        _memoryCache.TryGetValue($"{_prefix}Foo", out object objectValue).Should().BeTrue();
        objectValue.Should().Be(99);

        _prefixedCache.TryGetValue("Foo", out int intValue).Should().BeTrue();
        intValue.Should().Be(99);

        _prefixedCache.AffixedKeys.Should().BeEquivalentTo(new List<string>() { $"{_prefix}Foo" });
        _prefixedCache.UnaffixedKeys.Should().BeEquivalentTo(new List<string>() { "Foo" });
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
        var prefixedCache = new PrefixedMemoryCache<int>(genericCache, _prefix);

        mockMemoryCache.Setup(cache => cache.CreateEntry($"{_prefix}Foo")).Returns(mockCacheEntry.Object);

        // Act
        prefixedCache.Set("Foo", 99, new MemoryCacheEntryOptions()
        {
            AbsoluteExpiration = new DateTime(2015, 5, 6),
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
            ExpirationTokens = new List<IChangeToken>() { mockChangeToken.Object },
            Priority = CacheItemPriority.NeverRemove,
            Size = 1234,
            SlidingExpiration = TimeSpan.FromMinutes(30)
        });

        // Assert
        mockMemoryCache.Verify(cache => cache.CreateEntry($"{_prefix}Foo"), Times.Once);

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
        _prefixedCache.Set("Foo", 45, new MemoryCacheEntryOptions());

        // Act
        _prefixedCache.Set("Foo", 99, new MemoryCacheEntryOptions());

        // Assert
        _memoryCache.TryGetValue($"{_prefix}Foo", out object objectValue).Should().BeTrue();
        objectValue.Should().Be(99);

        _prefixedCache.TryGetValue($"Foo", out int intValue).Should().BeTrue();
        intValue.Should().Be(99);

        _prefixedCache.AffixedKeys.Should().BeEquivalentTo(new List<string>() { $"{_prefix}Foo" });
        _prefixedCache.UnaffixedKeys.Should().BeEquivalentTo(new List<string>() { "Foo" });
    }

    [Fact]
    public void Remove_DoesNotExist()
    {
        // Arrange
        _prefixedCache.Set("Bar", 99, new MemoryCacheEntryOptions());

        // Act
        _prefixedCache.Remove("Foo");

        // Assert
        _prefixedCache.AffixedKeys.Should().BeEquivalentTo(new List<string>() { $"{_prefix}Bar" });
        _prefixedCache.UnaffixedKeys.Should().BeEquivalentTo(new List<string>() { "Bar" });
    }

    [Fact]
    public void Remove_Exists()
    {
        // Arrange
        _prefixedCache.Set("Foo", 123, new MemoryCacheEntryOptions());

        // Act
        _prefixedCache.Remove("Foo");

        // Assert
        _prefixedCache.AffixedKeys.Should().BeEmpty();
        _prefixedCache.UnaffixedKeys.Should().BeEmpty();
    }

    [Fact]
    public void NoPrefix_UsesNameOfValue()
    {
        // Arrange
        var prefixedCache = new PrefixedMemoryCache<int>(_genericCache);

        // Act
        prefixedCache.Set("Foo", 99, new MemoryCacheEntryOptions());

        // Assert
        _memoryCache.TryGetValue($"Int32-Foo", out object objectValue).Should().BeTrue();
        objectValue.Should().Be(99);

        prefixedCache.TryGetValue("Foo", out int intValue).Should().BeTrue();
        intValue.Should().Be(99);

        prefixedCache.AffixedKeys.Should().BeEquivalentTo(new List<string>() { "Int32-Foo" });
        prefixedCache.UnaffixedKeys.Should().BeEquivalentTo(new List<string>() { "Foo" });
    }
}
