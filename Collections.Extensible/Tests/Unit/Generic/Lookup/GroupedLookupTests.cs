using System.Collections;
using Woody230.Collections.Extensible.Generic;
using Woody230.Collections.Extensible.Generic.Lookup;

namespace Woody230.Collections.Extensible.Tests.Unit.Generic.Lookup;

/// <summary>
/// Represents tests for a <see cref="GroupedLookup{TKey, TValue}"/>
/// </summary>
public class GroupedLookupTests
{
    private readonly IEnumerable<IGrouping<string, int>> _groupings =
    [
        new List<int>() { 5, 9, 124, 951 }.ToGrouping("foo"),
        new List<int>() { 812, 852, 456, 274 }.ToGrouping("bar"),
        new List<int>() { 985, 331, 980, 468, 576 }.ToGrouping("baz")
    ];

    [Fact]
    public void Index()
    {
        // Arrange
        var lookup = _groupings.ToLookup();

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
        var lookup = _groupings.ToLookup();

        // Act
        var count = lookup.Count();

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
        var lookup = _groupings.ToLookup();

        // Act
        var contains = lookup.Contains(key);

        // Assert
        contains.Should().Be(expected);
    }

    [Fact]
    public void GetEnumerator()
    {
        // Arrange
        var lookup = _groupings.ToLookup();

        // Act
        using var enumerator = lookup.GetEnumerator();

        // Assert
        var items = new List<IGrouping<string, int>>();
        while (enumerator.MoveNext())
        {
            items.Add(enumerator.Current);
        }

        items.Should().BeEquivalentTo(_groupings);
    }

    [Fact]
    public void InterfaceGetEnumerator()
    {
        // Arrange
        var lookup = _groupings.ToLookup();

        // Act
        var enumerator = ((IEnumerable)lookup).GetEnumerator();

        // Assert
        var items = new List<IGrouping<string, int>>();
        while (enumerator.MoveNext())
        {
            items.Add((IGrouping<string, int>)enumerator.Current);
        }

        items.Should().BeEquivalentTo(_groupings);
    }
}
