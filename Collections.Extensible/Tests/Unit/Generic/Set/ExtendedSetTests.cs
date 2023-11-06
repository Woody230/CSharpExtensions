using FluentAssertions;
using System.Collections.Generic;
using Woody230.Collections.Extensible.Generic;
using Xunit;

namespace Woody230.Collections.Extensible.Tests.Unit.Generic.Set;
public class ExtendedSetTests
{
    [Fact]
    public void AddCollection()
    {
        // Arrange
        ExtendedSet<int> first = new ExtendedSet<int>() { 5, 8, 13 };
        ExtendedSet<int> second = new ExtendedSet<int>() { 9, 13, 17 };

        // Act
        ExtendedSet<int> merged = first + second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo(new ExtendedSet<int>() { 5, 8, 13, 9, 13, 17 });
    }

    [Fact]
    public void AddCollection_Reverse()
    {
        // Arrange
        ExtendedSet<int> first = new ExtendedSet<int>() { 9, 13, 17 };
        ExtendedSet<int> second = new ExtendedSet<int>() { 5, 8, 13 };

        // Act
        ExtendedSet<int> merged = first + second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo(new ExtendedSet<int>() { 5, 8, 13, 9, 17 });
    }

    [Fact]
    public void SubtractCollection()
    {
        // Arrange
        ExtendedSet<int> first = new ExtendedSet<int>() { 5, 8, 13 };
        ExtendedSet<int> second = new ExtendedSet<int>() { 9, 13, 17 };

        // Act
        ExtendedSet<int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo(new ExtendedSet<int>() { 5, 8 });
    }

    [Fact]
    public void SubtractCollection_Reverse()
    {
        // Arrange
        ExtendedSet<int> first = new ExtendedSet<int>() { 9, 13, 17 };
        ExtendedSet<int> second = new ExtendedSet<int>() { 5, 8, 13 };

        // Act
        ExtendedSet<int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo(new ExtendedSet<int>() { 9, 17 });
    }

    [Fact]
    public void AddItem()
    {
        // Arrange
        ExtendedSet<int> first = new ExtendedSet<int>() { 5, 8, 13 };
        int second = 14;

        // Act
        ExtendedSet<int> merged = first + second;

        // Assert
        merged.Should().NotBeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedSet<int>() { 5, 8, 13, 14 });
    }

    [Fact]
    public void SubtractItem()
    {
        // Arrange
        ExtendedSet<int> first = new ExtendedSet<int>() { 5, 8, 13 };
        int second = 13;

        // Act
        ExtendedSet<int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedSet<int>() { 5, 8 });
    }

    [Fact]
    public void ShallowCopy()
    {
        // Arrange
        ExtendedSet<int> set = new ExtendedSet<int>() { 5, 8, 13 };

        // Act
        ExtendedSet<int> copy = set + 99;

        // Assert
        copy.Should().NotBeSameAs(set);

        set.Should().BeEquivalentTo(new HashSet<int>() { 5, 8, 13 });
        copy.Should().BeEquivalentTo(new HashSet<int>() { 5, 8, 13, 99 });
    }
}
