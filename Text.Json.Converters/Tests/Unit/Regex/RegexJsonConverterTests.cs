using System.Text.Json;
using Woody230.Function;

namespace Woody230.Text.Json.Converters.Tests.Unit.Regex;

/// <summary>
/// Represents tests for the <see cref="RegexJsonConverter"/>
/// </summary>
public class RegexJsonConverterTests
{
    private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions().Apply(options =>
    {
        options.WriteIndented = true;
        options.Converters.Add(new RegexJsonConverter());
    });

    [Fact]
    public void Read()
    {
        // Arrange
        var testObject = new TestRegexObject()
        {
            Regex = new("^(1|3|7)(2|4|9)$")
        };

        const string json = $$"""
        {
          "Regex": "^(1|3|7)(2|4|9)$"
        }
        """;

        // Act
        var deserialized = JsonSerializer.Deserialize<TestRegexObject>(json, _serializerOptions);

        // Assert
        deserialized.Should().BeEquivalentTo(testObject);
        deserialized.Regex.IsMatch("19").Should().BeTrue();
        deserialized.Regex.IsMatch("47").Should().BeFalse();
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
        var deserialized = JsonSerializer.Deserialize<TestRegexObject>(json, _serializerOptions);

        // Assert
        deserialized.Should().BeEquivalentTo(testObject);
    }

    [Fact]
    public void Write()
    {
        // Arrange
        var testObject = new TestRegexObject()
        {
            Regex = new("^(1|3|7)(2|4|9)$")
        };

        const string json = $$"""
        {
          "Regex": "^(1|3|7)(2|4|9)$"
        }
        """;

        // Act
        var deserialized = JsonSerializer.Serialize(testObject, _serializerOptions);

        // Assert
        deserialized.Should().Be(json);
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
        var deserialized = JsonSerializer.Serialize(testObject, _serializerOptions);

        // Assert
        deserialized.Should().Be(json);
    }
}
