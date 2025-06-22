using System.Collections;
using Woody230.Collections.Generic;
using Woody230.Collections.Generic.Lookup;

namespace Woody230.Collections.Tests.Unit.Generic.Lookup;

/// <summary>
/// Represents tests for a <see cref="Grouping{TKey, TElement}"/>
/// </summary>
public class GroupingTests
{
    private readonly List<int> _collection = [5, 9, 124, 951];

    [Fact]
    public void Key()
    {
        // Arrange
        var grouping = _collection.ToGrouping("foo");

        // Act
        var key = grouping.Key;

        // Assert
        key.Should().Be("foo");
    }

    [Fact]
    public void GetEnumerator()
    {
        // Arrange
        var grouping = _collection.ToGrouping("foo");

        // Act
        using var enumerator = grouping.GetEnumerator();

        // Assert
        var items = new List<int>();
        while (enumerator.MoveNext())
        {
            items.Add(enumerator.Current);
        }

        items.Should().BeEquivalentTo(_collection);
    }

    [Fact]
    public void InterfaceGetEnumerator()
    {
        // Arrange
        var grouping = _collection.ToGrouping("foo");

        // Act
        var enumerator = ((IEnumerable)grouping).GetEnumerator();

        // Assert
        var items = new List<int>();
        while (enumerator.MoveNext())
        {
            items.Add((int)enumerator.Current);
        }

        items.Should().BeEquivalentTo(_collection);
    }
}
