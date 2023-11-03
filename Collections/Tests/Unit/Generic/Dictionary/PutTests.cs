using FluentAssertions;
using System.Collections.Generic;
using Woody230.Collections.Generic;
using Xunit;

namespace Woody230.Collections.Tests.Unit.Generic.Dictionary;
public class PutTests
{
    [Fact]
    public void Put_WithDuplicate_Updates()
    {
        // Arrange / Act
        var dictionary = new Dictionary<string, int>();
        dictionary.Put("Foo", 5);
        dictionary.Put("Bar", 7);
        dictionary.Put("Baz", 1094);
        dictionary.Put("Foo", 99);
        dictionary.Put("Fizz", 159);
        dictionary.Put("Baz", 1021);
        dictionary.Put("Buzz", 222);

        // Assert
        dictionary.Should().BeEquivalentTo(new Dictionary<string, int>()
        {
            ["Foo"] = 99,
            ["Bar"] = 7,
            ["Baz"] = 1021,
            ["Fizz"] = 159,
            ["Buzz"] = 222
        });
    }
}
