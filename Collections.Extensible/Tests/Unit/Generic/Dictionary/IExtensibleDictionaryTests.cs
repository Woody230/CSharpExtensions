using FluentAssertions;
using System.Collections.Generic;
using Woody230.Collections.Extensible.Generic;
using Xunit;

namespace Woody230.Collections.Extensible.Tests.Unit.Generic.Dictionary;
public class IExtensibleDictionaryTests
{
    [Fact]
    public void AddCollection()
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
            ["FooBar"] = 13,
            ["Buzz"] = 17,
            ["FooBaz"] = 99
        };

        // Act
        IExtensibleDictionary<string, int> merged = first + second;

        // Assert
        merged.Should().BeSameAs(first);
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
    public void AddCollection_Reverse()
    {
        // Arrange
        IExtensibleDictionary<string, int> first = new ExtendedDictionary<string, int>()
        {
            ["Fizz"] = 9,
            ["FooBar"] = 13,
            ["Buzz"] = 17,
            ["FooBaz"] = 99
        };
        IExtensibleDictionary<string, int> second = new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };

        // Act
        IExtensibleDictionary<string, int> merged = first + second;

        // Assert
        merged.Should().BeSameAs(first);
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
            ["Foo"] = 13,
            ["Buzz"] = 17,
            ["Baz"] = 13
        };

        // Act
        IExtensibleDictionary<string, int> merged = first - second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8
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
            ["Buzz"] = 17,
            ["Baz"] = 13
        };
        IExtensibleDictionary<string, int> second = new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };

        // Act
        IExtensibleDictionary<string, int> merged = first - second;

        // Assert
        merged.Should().BeSameAs(first);
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
        IExtensibleDictionary<string, int> first = new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        KeyValuePair<string, int> second = KeyValuePair.Create("Fizz", 9);

        // Act
        IExtensibleDictionary<string, int> merged = first + second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13,
            ["Fizz"] = 9
        });
    }

    [Fact]
    public void SubtractItem()
    {
        // Arrange
        IExtensibleDictionary<string, int> first = new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8,
            ["Baz"] = 13
        };
        KeyValuePair<string, int> second = KeyValuePair.Create("Baz", 13);

        // Act
        IExtensibleDictionary<string, int> merged = first - second;

        // Assert
        merged.Should().BeSameAs(first);
        merged.Should().BeEquivalentTo(new ExtendedDictionary<string, int>()
        {
            ["Foo"] = 5,
            ["Bar"] = 8
        });
    }
}
