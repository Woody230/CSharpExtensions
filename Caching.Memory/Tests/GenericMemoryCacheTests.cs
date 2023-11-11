using Microsoft.Extensions.Caching.Memory;

namespace Woody230.Caching.Memory.Tests;

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
