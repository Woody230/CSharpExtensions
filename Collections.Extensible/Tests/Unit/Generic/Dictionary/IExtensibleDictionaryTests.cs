using FluentAssertions;
using Woody230.Collections.Extensible.Generic;
using Xunit;

namespace Woody230.Collections.Extensible.Tests.Unit.Generic.Dictionary;
public class IExtensibleDictionaryTests
{
    [Fact]
    public void AddCollection()
    {
        // Arrange
        IExtensibleDictionary<string, int> first = new LenientDictionary<string, int>() 
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        IExtensibleDictionary<string, int> second = new ExtendedDictionary<string, int>() 
        {
            ["Fizz"] = 9,
            ["FooBar"] = 13,
            ["Bar"] = 102,
            ["Buzz"] = 17,
            ["FooBaz"] = 99,
        };

        // Act
        IExtensibleDictionary<string, int> merged = first + second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo(new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 102,
            ["Baz"] = 13,
            ["Fizz"] = 9,
            ["FooBar"] = 13,
            ["Buzz"] = 17,
            ["FooBaz"] = 99
        });
    }

    [Fact]
    public void AddCollection_Reverse()
    {
        // Arrange
        IExtensibleDictionary<string, int> first = new ExtendedDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["FooBar"] = 13,
            ["Bar"] = 102,
            ["Buzz"] = 17,
            ["FooBaz"] = 99
        };
        IExtensibleDictionary<string, int> second = new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };

        // Act
        Action action = () => _ = first + second;

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage("An item with the same key has already been added. Key: Bar");
    }

    [Fact]
    public void SubtractCollection()
    {
        // Arrange
        IExtensibleDictionary<string, int> first = new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        IExtensibleDictionary<string, int> second = new ExtendedDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["Bar"] = 102,
            ["Buzz"] = 17,
            ["Baz"] = 13
        };

        // Act
        IExtensibleDictionary<string, int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo(new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5
        });
    }

    [Fact]
    public void SubtractCollection_Reverse()
    {
        // Arrange
        IExtensibleDictionary<string, int> first = new ExtendedDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["Foo"] = 13,
            ["Bar"] = 102,
            ["Buzz"] = 17,
            ["Baz"] = 13
        };
        IExtensibleDictionary<string, int> second = new ExtendedDictionary<string, int>()
        {
            ["Bar"] = 8,
            ["Baz"] = 13,
            ["FooBarBaz"] = 9102
        };

        // Act
        IExtensibleDictionary<string, int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo(new ExtendedDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["Foo"] = 13,
            ["Buzz"] = 17
        });
    }

    [Fact]
    public void AddItem()
    {
        // Arrange
        IExtensibleDictionary<string, int> first = new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        KeyValuePair<string, int> second = KeyValuePair.Create("Foo", 9);

        // Act
        IExtensibleDictionary<string, int> merged = first + second;

        // Assert
        merged.Should().NotBeSameAs(first);
        merged.Should().BeEquivalentTo(new LenientDictionary<string, int>()
        {
            ["Foo"] = 9,
            ["Bar"] = 8,
            ["Baz"] = 13
        });
    }

    [Theory]
    [InlineData(13)]
    [InlineData(17)]
    public void SubtractItem(int value)
    {
        // Arrange
        IExtensibleDictionary<string, int> first = new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        KeyValuePair<string, int> second = KeyValuePair.Create("Baz", value);

        // Act
        IExtensibleDictionary<string, int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first);
        merged.Should().BeEquivalentTo(new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8
        });
    }
}
