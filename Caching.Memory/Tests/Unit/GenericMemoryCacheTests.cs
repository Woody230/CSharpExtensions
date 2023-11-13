using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Woody230.Caching.Memory.Tests.Unit;

/// <summary>
/// Represents tests for the <see cref="GenericMemoryCacheTests{TKey, TValue}"/>
/// </summary>
public class GenericMemoryCacheTests
{
    private readonly IMemoryCache _memoryCache;
    private readonly IGenericMemoryCache<string, int> _genericCache;

    private readonly Mock<IMemoryCache> _mockMemoryCache;
    private readonly Mock<ICacheEntry> _mockCacheEntry;
    private readonly IList<IChangeToken> _changeTokens;
    private readonly Mock<IChangeToken> _mockChangeToken;
    private readonly IGenericMemoryCache<string, int> _mockGenericCache;

    private readonly IMemoryCacheEntryOptions _entryOptions;

    public GenericMemoryCacheTests()
    {
        _memoryCache = new MemoryCache(new MemoryCacheOptions());
        _genericCache = new GenericMemoryCache<string, int>(_memoryCache);

        _mockMemoryCache = new();
        _mockCacheEntry = new();
        _changeTokens = new List<IChangeToken>();
        _mockChangeToken = new();
        _mockGenericCache = new GenericMemoryCache<string, int>(_mockMemoryCache.Object);
        _mockCacheEntry.SetupGet(entry => entry.ExpirationTokens).Returns(_changeTokens);
        _mockMemoryCache.Setup(cache => cache.CreateEntry(It.IsAny<string>())).Returns(_mockCacheEntry.Object);

        _entryOptions = new MemoryCacheEntryOptions()
        {
            AbsoluteExpiration = new DateTime(2015, 5, 6),
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
            ExpirationTokens = new List<IChangeToken>() { _mockChangeToken.Object },
            Priority = CacheItemPriority.NeverRemove,
            Size = 1234,
            SlidingExpiration = TimeSpan.FromMinutes(30)
        };
    }

    [Fact]
    public void Set_DoesNotExist()
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
    public void Set_SetsEntryOptions()
    {
        // Act
        _mockGenericCache.Set("Foo", 99, _entryOptions);

        // Assert
        _mockMemoryCache.Verify(cache => cache.CreateEntry("Foo"), Times.Once);

        AssertEntryOptions();
    }

    [Fact]
    public void Set_Exists()
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

    #region Extensions

    [Fact]
    public void Clear()
    {
        // Arrange
        _genericCache.Set("Foo", 123, new MemoryCacheEntryOptions());
        _genericCache.Set("Bar", 456, new MemoryCacheEntryOptions());

        // Act
        _genericCache.Clear();

        // Assert
        _genericCache.Keys.Should().BeEmpty();
    }

    [Fact]
    public void Set_NoEntryOptions()
    {
        // Act
        _mockGenericCache.Set("Foo", 99);

        // Assert
        _mockMemoryCache.Verify(cache => cache.CreateEntry("Foo"), Times.Once);

        AssertNoEntryOptions();
    }

    [Fact]
    public void GetOrCreate_DoesNotExist()
    {
        // Act
        var value = _genericCache.GetOrCreate("Foo", _entryOptions, () => 5);

        // Assert
        value.Should().Be(5);

        _genericCache.Keys.Should().BeEquivalentTo(new List<string>() { "Foo" });
    }

    [Fact]
    public void GetOrCreate_Exists()
    {
        // Arrange
        _genericCache.Set("Foo", 99);

        // Act
        var value = _genericCache.GetOrCreate("Foo", _entryOptions, () => 5);

        // Assert
        value.Should().Be(99);

        _genericCache.Keys.Should().BeEquivalentTo(new List<string>() { "Foo" });
    }

    [Fact]
    public void GetOrCreate_SetsEntryOptions()
    {
        // Act
        _mockGenericCache.GetOrCreate("Foo", _entryOptions, () => 5);

        // Assert
        AssertEntryOptions();
    }

    [Fact]
    public void GetOrCreate_NoEntryOptions_DoesNotExist()
    {
        // Act
        var value = _genericCache.GetOrCreate("Foo", () => 5);

        // Assert
        value.Should().Be(5);

        _genericCache.Keys.Should().BeEquivalentTo(new List<string>() { "Foo" });
    }

    [Fact]
    public void GetOrCreate_NoEntryOptions_Exists()
    {
        // Arrange
        _genericCache.Set("Foo", 99);

        // Act
        var value = _genericCache.GetOrCreate("Foo", () => 5);

        // Assert
        value.Should().Be(99);
    }

    [Fact]
    public void GetOrCreate_NoEntryOptions_SetsNoEntryOptions()
    {
        // Act
        _mockGenericCache.GetOrCreate("Foo", () => 5);

        // Assert
        AssertNoEntryOptions();
    }

    #endregion Extensions

    private void AssertEntryOptions()
    {
        _mockCacheEntry.VerifySet(entry => entry.AbsoluteExpiration = new DateTime(2015, 5, 6));
        _mockCacheEntry.VerifySet(entry => entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1));
        _changeTokens.Should().BeEquivalentTo(new List<IChangeToken>() { _mockChangeToken.Object });
        _mockCacheEntry.VerifySet(entry => entry.Priority = CacheItemPriority.NeverRemove);
        _mockCacheEntry.VerifySet(entry => entry.Size = 1234);
        _mockCacheEntry.VerifySet(entry => entry.SlidingExpiration = TimeSpan.FromMinutes(30));
    }

    private void AssertNoEntryOptions()
    {
        _mockCacheEntry.VerifySet(entry => entry.AbsoluteExpiration = null);
        _mockCacheEntry.VerifySet(entry => entry.AbsoluteExpirationRelativeToNow = null);
        _changeTokens.Should().BeEquivalentTo(new List<IChangeToken>());
        _mockCacheEntry.VerifySet(entry => entry.Priority = CacheItemPriority.Normal);
        _mockCacheEntry.VerifySet(entry => entry.Size = null);
        _mockCacheEntry.VerifySet(entry => entry.SlidingExpiration = null);
    }
}
