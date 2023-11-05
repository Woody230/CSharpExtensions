using FluentAssertions;
using Woody230.Collections.Extensible.Generic;
using Xunit;

namespace Woody230.Collections.Extensible.Tests.Unit.Generic;
public class IExtensibleCollectionTests
{
    [Fact]
    public void AddCollection()
    {
        // Arrange
        IExtensibleCollection<int> first = new ExtendedList<int>() { 5, 8, 13 };
        IExtensibleCollection<int> second = new ExtendedSet<int>() { 9, 13, 17 };

        // Act
        IExtensibleCollection<int> merged = first + second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedList<int>() { 5, 8, 13, 9, 13, 17 });
    }

    [Fact]
    public void AddCollection_Reverse()
    {
        // Arrange
        IExtensibleCollection<int> first = new ExtendedSet<int>() { 9, 13, 17 };
        IExtensibleCollection<int> second = new ExtendedList<int>() { 5, 8, 13 };

        // Act
        IExtensibleCollection<int> merged = first + second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedSet<int>() { 5, 8, 13, 9, 17 });
    }

    [Fact]
    public void SubtractCollection()
    {
        // Arrange
        IExtensibleCollection<int> first = new ExtendedList<int>() { 5, 8, 13 };
        IExtensibleCollection<int> second = new ExtendedSet<int>() { 9, 13, 17 };

        // Act
        IExtensibleCollection<int> merged = first - second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedList<int>() { 5, 8 });
    }

    [Fact]
    public void SubtractCollection_Reverse()
    {
        // Arrange
        IExtensibleCollection<int> first = new ExtendedSet<int>() { 9, 13, 17 };
        IExtensibleCollection<int> second = new ExtendedList<int>() { 5, 8, 13 };

        // Act
        IExtensibleCollection<int> merged = first - second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedSet<int>() { 9, 17 });
    }
}
