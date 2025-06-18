using Woody230.Collections.Extensible.Generic;

namespace Woody230.Collections.Extensible.Tests.Unit.Generic.List;
public class IExtensibleListTests
{
    [Fact]
    public void AddCollection()
    {
        // Arrange
        IExtensibleList<int> first = new ExtendedList<int>() { 5, 8, 13 };
        IExtensibleList<int> second = new ExtendedList<int>() { 9, 13, 17 };

        // Act
        IExtensibleList<int> merged = first + second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo([5, 8, 13, 9, 13, 17]);
    }

    [Fact]
    public void AddCollection_Reverse()
    {
        // Arrange
        IExtensibleList<int> first = new ExtendedList<int>() { 9, 13, 17 };
        IExtensibleList<int> second = new ExtendedList<int>() { 5, 8, 13 };

        // Act
        IExtensibleList<int> merged = first + second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo([5, 8, 13, 9, 13, 17]);
    }

    [Fact]
    public void SubtractCollection()
    {
        // Arrange
        IExtensibleList<int> first = new ExtendedList<int>() { 5, 8, 13 };
        IExtensibleList<int> second = new ExtendedList<int>() { 9, 13, 17 };

        // Act
        IExtensibleList<int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo([5, 8]);
    }

    [Fact]
    public void SubtractCollection_Reverse()
    {
        // Arrange
        IExtensibleList<int> first = new ExtendedList<int>() { 9, 13, 17 };
        IExtensibleList<int> second = new ExtendedList<int>() { 5, 8, 13 };

        // Act
        IExtensibleList<int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo([9, 17]);
    }

    [Fact]
    public void AddItem()
    {
        // Arrange
        IExtensibleList<int> first = new ExtendedList<int>() { 5, 8, 13 };
        int second = 13;

        // Act
        IExtensibleList<int> merged = first + second;

        // Assert
        merged.Should().NotBeSameAs(first);
        merged.Should().BeEquivalentTo([5, 8, 13, 13]);
    }

    [Fact]
    public void SubtractItem()
    {
        // Arrange
        IExtensibleList<int> first = new ExtendedList<int>() { 5, 8, 13 };
        int second = 13;

        // Act
        IExtensibleList<int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first);
        merged.Should().BeEquivalentTo([5, 8]);
    }
}
