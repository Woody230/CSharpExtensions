using Woody230.Collections.Generic;

namespace Woody230.Collections.Tests.Unit.Generic.Dictionary;
public class ToDictionaryTests
{
    #if NET6_0
    [Fact]
    public void Tuples()
    {
        // Arrange
        var tuples = new List<(string, int)>()
        {
            ("Foo", 1),
            ("Bar", 4),
            ("Baz", 9)
        };

        // Act
        IDictionary<string, int> dictionary = tuples.ToDictionary();

        // Assert
        dictionary.Should().BeEquivalentTo(new Dictionary<string, int>()
        {
            ["Foo"] = 1,
            ["Bar"] = 4,
            ["Baz"] = 9
        });
    }
    #endif
}
