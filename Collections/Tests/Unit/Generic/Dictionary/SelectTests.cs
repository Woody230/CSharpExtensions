using Woody230.Collections.Generic;

namespace Woody230.Collections.Tests.Unit.Generic.Dictionary;
public class SelectTests
{
    [Fact]
    public void SelectKeys()
    {
        // Arrange / Act
        IDictionary<string, int> dictionary = new Dictionary<string, int>()
        {
            ["Foo"] = 7,
            ["Bar"] = 1284,
            ["Baz"] = 721
        }
        .SelectKeys(key => key)
        .SelectKeys(Prefix)
        .SelectKeys(Postfix);

        // Assert
        dictionary.Should().BeEquivalentTo(new Dictionary<string, int>()
        {
            ["@Foo!"] = 7,
            ["@Bar!"] = 1284,
            ["@Baz!"] = 721
        });

        string Prefix(string key) => "@" + key;
        string Postfix(string key) => key + "!";
    }

    [Fact]
    public void SelectValues()
    {
        // Arrange / Act
        IDictionary<string, decimal> dictionary = new Dictionary<string, int>()
        {
            ["Foo"] = 7,
            ["Bar"] = 1284,
            ["Baz"] = 721
        }
        .SelectValues(value => value)
        .SelectValues(Add)
        .SelectValues(ToDecimal);

        // Assert
        dictionary.Should().BeEquivalentTo(new Dictionary<string, decimal>()
        {
            ["Foo"] = 16M,
            ["Bar"] = 1293M,
            ["Baz"] = 730M
        });

        int Add(int value) => value + 9;
        decimal ToDecimal(int value) => value;
    }
}
