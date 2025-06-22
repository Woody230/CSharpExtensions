using System.Collections;
using Woody230.Collections.Generic;
using Woody230.Collections.Generic.Lookup;

namespace Woody230.Collections.Tests.Unit.Generic.Lookup;

/// <summary>
/// Represents tests for a <see cref="GroupedLookup{TKey, TValue}"/> using a dictionary.
/// </summary>
public class DictionaryLookupTests
{
    private readonly Dictionary<string, IEnumerable<int>> _dictionary = new()
    {
        ["foo"] = [5, 9, 124, 951],
        ["bar"] = [812, 852, 456, 274],
        ["baz"] = [985, 331, 980, 468, 576]
    };

    [Fact]
    public void Index()
    {
        // Arrange
        var lookup = _dictionary.ToLookup();

        // Act / Assert
        lookup["foo"].Should().BeEquivalentTo([5, 9, 124, 951]);
        lookup["bar"].Should().BeEquivalentTo([812, 852, 456, 274]);
        lookup["baz"].Should().BeEquivalentTo([985, 331, 980, 468, 576]);
        lookup["unknown"].Should().BeEmpty();
    }

    [Fact]
    public void Count()
    {
        // Arrange
        var lookup = _dictionary.ToLookup();

        // Act
        var count = lookup.Count;

        // Assert
        count.Should().Be(3);
    }

    [Theory]
    [InlineData("foo", true)]
    [InlineData("bar", true)]
    [InlineData("baz", true)]
    [InlineData("unknown", false)]
    public void Contains(string key, bool expected)
    {
        // Arrange
        var lookup = _dictionary.ToLookup();

        // Act
        var contains = lookup.Contains(key);

        // Assert
        contains.Should().Be(expected);
    }

    [Fact]
    public void GetEnumerator()
    {
        // Arrange
        var lookup = _dictionary.ToLookup();

        // Act
        using var enumerator = lookup.GetEnumerator();

        // Assert
        var items = new List<IGrouping<string, int>>();
        while (enumerator.MoveNext())
        {
            items.Add(enumerator.Current);
        }

        items.Count.Should().Be(_dictionary.Count);
        foreach (var (group, pair) in items.Zip(_dictionary))
        {
            group.Key.Should().Be(pair.Key);
            group.Should().BeEquivalentTo(pair.Value);
        }
    }

    [Fact]
    public void InterfaceGetEnumerator()
    {
        // Arrange
        var lookup = _dictionary.ToLookup();

        // Act
        var enumerator = ((IEnumerable)lookup).GetEnumerator();

        // Assert
        var items = new List<IGrouping<string, int>>();
        while (enumerator.MoveNext())
        {
            items.Add((IGrouping<string, int>)enumerator.Current);
        }

        items.Count.Should().Be(_dictionary.Count);
        foreach (var (group, pair) in items.Zip(_dictionary))
        {
            group.Key.Should().Be(pair.Key);
            group.Should().BeEquivalentTo(pair.Value);
        }
    }
}

