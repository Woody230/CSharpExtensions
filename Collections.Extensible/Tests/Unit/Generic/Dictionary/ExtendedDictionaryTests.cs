using FluentAssertions;
using System;
using System.Collections.Generic;
using Woody230.Collections.Extensible.Generic;
using Xunit;

namespace Woody230.Collections.Extensible.Tests.Unit.Generic.Dictionary;
public class ExtendedDictionaryTests
{

    [Fact]
    public void AddCollection()
    {
        // Arrange
        ExtendedDictionary<string, int> first = new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        ExtendedDictionary<string, int> second = new ExtendedDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["FooBar"] = 13,
            ["Buzz"] = 17,
            ["FooBaz"] = 99,
        };

        // Act
        ExtendedDictionary<string, int> merged = first + second;

        // Assert
        merged.Should().NotBeSameAs(first).And.NotBeSameAs(second);
        merged.Should().BeEquivalentTo(new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13,
            ["Fizz"] = 9,
            ["FooBar"] = 13,
            ["Buzz"] = 17,
            ["FooBaz"] = 99
        });
    }

    [Fact]
    public void AddCollection_Duplicate()
    {
        // Arrange
        ExtendedDictionary<string, int> first = new ExtendedDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["FooBar"] = 13,
            ["Bar"] = 102,
            ["Buzz"] = 17,
            ["FooBaz"] = 99
        };
        ExtendedDictionary<string, int> second = new ExtendedDictionary<string, int>()
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
        ExtendedDictionary<string, int> first = new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        ExtendedDictionary<string, int> second = new ExtendedDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["Bar"] = 102,
            ["Buzz"] = 17,
            ["Baz"] = 13
        };

        // Act
        ExtendedDictionary<string, int> merged = first - second;

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
        ExtendedDictionary<string, int> first = new ExtendedDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["Foo"] = 13,
            ["Bar"] = 102,
            ["Buzz"] = 17,
            ["Baz"] = 13
        };
        ExtendedDictionary<string, int> second = new ExtendedDictionary<string, int>()
        {
            ["Bar"] = 8,
            ["Baz"] = 13,
            ["FooBarBaz"] = 9102
        };

        // Act
        ExtendedDictionary<string, int> merged = first - second;

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
        ExtendedDictionary<string, int> first = new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        KeyValuePair<string, int> second = KeyValuePair.Create("Fizz", 9);

        // Act
        ExtendedDictionary<string, int> merged = first + second;

        // Assert
        merged.Should().NotBeSameAs(first);
        merged.Should().BeEquivalentTo(new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13,
            ["Fizz"] = 9
        });
    }

    [Theory]
    [InlineData(13)]
    [InlineData(17)]
    public void SubtractItem(int value)
    {
        // Arrange
        ExtendedDictionary<string, int> first = new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        KeyValuePair<string, int> second = KeyValuePair.Create("Baz", value);

        // Act
        ExtendedDictionary<string, int> merged = first - second;

        // Assert
        merged.Should().NotBeSameAs(first);
        merged.Should().BeEquivalentTo(new LenientDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8
        });
    }

    [Fact]
    public void ShallowCopy()
    {
        // Arrange
        ExtendedDictionary<string, int> dictionary = new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };

        // Act
        ExtendedDictionary<string, int> copy = dictionary.ShallowCopy() + KeyValuePair.Create("Fizz", 45);

        // Assert
        copy.Should().NotBeSameAs(dictionary);

        dictionary.Should().BeEquivalentTo(new Dictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        });
        copy.Should().BeEquivalentTo(new Dictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13,
            ["Fizz"] = 45
        });
    }
}
