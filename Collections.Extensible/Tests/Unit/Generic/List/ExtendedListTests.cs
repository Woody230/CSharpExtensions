using FluentAssertions;
using Woody230.Collections.Extensible.Generic;
using Xunit;

namespace Woody230.Collections.Extensible.Tests.Unit.Generic.List;
public class ExtendedListTests
{
    [Fact]
    public void AddCollection()
    {
        // Arrange
        ExtendedList<int> first = new ExtendedList<int>() { 5, 8, 13 };
        ExtendedList<int> second = new ExtendedList<int>() { 9, 13, 17 };

        // Act
        ExtendedList<int> merged = first + second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedList<int>() { 5, 8, 13, 9, 13, 17 });
    }

    [Fact]
    public void AddCollection_Reverse()
    {
        // Arrange
        ExtendedList<int> first = new ExtendedList<int>() { 9, 13, 17 };
        ExtendedList<int> second = new ExtendedList<int>() { 5, 8, 13 };

        // Act
        ExtendedList<int> merged = first + second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedList<int>() { 5, 8, 13, 9, 13, 17 });
    }

    [Fact]
    public void SubtractCollection()
    {
        // Arrange
        ExtendedList<int> first = new ExtendedList<int>() { 5, 8, 13 };
        ExtendedList<int> second = new ExtendedList<int>() { 9, 13, 17 };

        // Act
        ExtendedList<int> merged = first - second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedList<int>() { 5, 8 });
    }

    [Fact]
    public void SubtractCollection_Reverse()
    {
        // Arrange
        ExtendedList<int> first = new ExtendedList<int>() { 9, 13, 17 };
        ExtendedList<int> second = new ExtendedList<int>() { 5, 8, 13 };

        // Act
        ExtendedList<int> merged = first - second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedList<int>() { 9, 17 });
    }

    [Fact]
    public void AddItem()
    {
        // Arrange
        ExtendedList<int> first = new ExtendedList<int>() { 5, 8, 13 };
        int second = 13;

        // Act
        ExtendedList<int> merged = first + second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedList<int>() { 5, 8, 13, 13 });
    }

    [Fact]
    public void SubtractItem()
    {
        // Arrange
        ExtendedList<int> first = new ExtendedList<int>() { 5, 8, 13 };
        int second = 13;

        // Act
        ExtendedList<int> merged = first - second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedList<int>() { 5, 8 });
    }
}
