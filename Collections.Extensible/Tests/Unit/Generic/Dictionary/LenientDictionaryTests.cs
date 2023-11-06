using FluentAssertions;
using System.Collections.Generic;
using Woody230.Collections.Extensible.Generic;
using Xunit;

namespace Woody230.Collections.Extensible.Tests.Unit.Generic.Dictionary;
public class LenientDictionaryTests
{
    [Fact]
    public void AddCollection()
    {
        // Arrange
        LenientDictionary<string, int> first = new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        LenientDictionary<string, int> second = new LenientDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["FooBar"] = 13,
            ["Bar"] = 102,
            ["Buzz"] = 17,
            ["FooBaz"] = 99,
        };

        // Act
        LenientDictionary<string, int> merged = first + second;

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
        LenientDictionary<string, int> first = new LenientDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["FooBar"] = 13,
            ["Bar"] = 102,
            ["Buzz"] = 17,
            ["FooBaz"] = 99
        };
        LenientDictionary<string, int> second = new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };

        // Act
        LenientDictionary<string, int> merged = first + second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo(new LenientDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["FooBar"] = 13,
            ["Bar"] = 8,
            ["Buzz"] = 17,
            ["FooBaz"] = 99,
            ["Foo"] = 5,
            ["Baz"] = 13
        });
    }

    [Fact]
    public void SubtractCollection()
    {
        // Arrange
        LenientDictionary<string, int> first = new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        LenientDictionary<string, int> second = new LenientDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["Bar"] = 102,
            ["Buzz"] = 17,
            ["Baz"] = 13
        };

        // Act
        LenientDictionary<string, int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo(new LenientDictionary<string, int>()
        {
            ["Foo"] = 5
        });
    }

    [Fact]
    public void SubtractCollection_Reverse()
    {
        // Arrange
        LenientDictionary<string, int> first = new LenientDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["Foo"] = 13,
            ["Bar"] = 102,
            ["Buzz"] = 17,
            ["Baz"] = 13
        };
        LenientDictionary<string, int> second = new LenientDictionary<string, int>()
        {
            ["Bar"] = 8,
            ["Baz"] = 13,
            ["FooBarBaz"] = 9102
        };

        // Act
        LenientDictionary<string, int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo(new LenientDictionary<string, int>()
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
        LenientDictionary<string, int> first = new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        KeyValuePair<string, int> second = KeyValuePair.Create("Foo", 9);

        // Act
        LenientDictionary<string, int> merged = first + second;

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
        LenientDictionary<string, int> first = new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        KeyValuePair<string, int> second = KeyValuePair.Create("Baz", value);

        // Act
        LenientDictionary<string, int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first);
        merged.Should().BeEquivalentTo(new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8
        });
    }
}