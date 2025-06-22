using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Woody230.Text.Json.Converters.Tests.Unit.Regex;

/// <summary>
/// Represents tests related to a regex <see cref="JsonConverter"/>
/// </summary>
public abstract class BaseRegexJsonConverterTests<TConverter>: BaseJsonConverterTests where TConverter : JsonConverter<System.Text.RegularExpressions.Regex>, new()
{
    protected abstract RegexOptions RegexOptions { get; }

    private const string RegexPattern = "^(1|3|7)(2|4|9)$";

    protected BaseRegexJsonConverterTests()
    {
        SerializerOptions.Converters.Add(new TConverter());
    }

    [Fact]
    public void Read()
    {
        // Arrange
        var testObject = new TestRegexObject()
        {
            Regex = new(RegexPattern, RegexOptions)
        };

        var json = $$"""
        {
          "Regex": "{{RegexPattern}}"
        }
        """;

        // Act
        var deserialized = JsonSerializer.Deserialize<TestRegexObject>(json, SerializerOptions);

        // Assert
        deserialized.Should().BeEquivalentTo(testObject);
        deserialized.Regex.IsMatch("19").Should().BeTrue();
        deserialized.Regex.IsMatch("47").Should().BeFalse();
    }

    [Theory]
    [InlineData(RegexOptions.Compiled)]
    [InlineData(RegexOptions.None)]
    public void Write(RegexOptions options)
    {
        // Arrange
        var testObject = new TestRegexObject()
        {
            Regex = new(RegexPattern, options)
        };

        var json = $$"""
        {
          "Regex": "{{RegexPattern}}"
        }
        """;

        // Act
        var deserialized = JsonSerializer.Serialize(testObject, SerializerOptions);

        // Assert
        deserialized.Should().Be(json);
    }

    [Fact]
    public void ReadNull()
    {
        // Arrange
        var testObject = new TestRegexObject()
        {
            Regex = null
        };

        const string json = $$"""
        {
          "Regex": null
        }
        """;

        // Act
        var deserialized = JsonSerializer.Deserialize<TestRegexObject>(json, SerializerOptions);

        // Assert
        deserialized.Should().BeEquivalentTo(testObject);
    }

    [Fact]
    public void WriteNull()
    {
        // Arrange
        var testObject = new TestRegexObject()
        {
            Regex = null
        };

        const string json = $$"""
        {
          "Regex": null
        }
        """;

        // Act
        var deserialized = JsonSerializer.Serialize(testObject, SerializerOptions);

        // Assert
        deserialized.Should().Be(json);
    }
}
