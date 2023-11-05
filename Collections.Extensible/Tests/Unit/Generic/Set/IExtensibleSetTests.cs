using FluentAssertions;
using Woody230.Collections.Extensible.Generic;
using Xunit;

namespace Woody230.Collections.Extensible.Tests.Unit.Generic.Set;
public class IExtensibleSetTests
{
    [Fact]
    public void Add()
    {
        // Arrange
        IExtensibleSet<int> first = new ExtendedSet<int>() { 5, 8, 13 };
        IExtensibleSet<int> second = new ExtendedSet<int>() { 9, 13, 17 };

        // Act
        IExtensibleSet<int> merged = first + second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedSet<int>() { 5, 8, 13, 9, 13, 17 });
    }

    [Fact]
    public void AddReverse()
    {
        // Arrange
        IExtensibleSet<int> first = new ExtendedSet<int>() { 9, 13, 17 };
        IExtensibleSet<int> second = new ExtendedSet<int>() { 5, 8, 13 };

        // Act
        IExtensibleSet<int> merged = first + second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedSet<int>() { 5, 8, 13, 9, 17 });
    }

    [Fact]
    public void Subtract()
    {
        // Arrange
        IExtensibleSet<int> first = new ExtendedSet<int>() { 5, 8, 13 };
        IExtensibleSet<int> second = new ExtendedSet<int>() { 9, 13, 17 };

        // Act
        IExtensibleSet<int> merged = first - second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedSet<int>() { 5, 8 });
    }

    [Fact]
    public void SubtractReverse()
    {
        // Arrange
        IExtensibleSet<int> first = new ExtendedSet<int>() { 9, 13, 17 };
        IExtensibleSet<int> second = new ExtendedSet<int>() { 5, 8, 13 };

        // Act
        IExtensibleSet<int> merged = first - second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedSet<int>() { 9, 17 });
    }
}
