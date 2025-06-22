using System.Text.Json;
using System.Text.Json.Serialization;

namespace Woody230.Text.Json.Converters.Tests.Unit.Uri;

/// <summary>
/// Represents tests related to a <see cref="JsonConverter{System.Uri}"/>
/// </summary>
public abstract class BaseUriJsonConverterTests<TConverter> : BaseJsonConverterTests where TConverter : JsonConverter<System.Uri>, new()
{
    protected abstract UriKind UriKind { get; }
    protected abstract string Uri { get; }

    protected BaseUriJsonConverterTests()
    {
        SerializerOptions.Converters.Add(new TConverter());
    }

    [Fact]
    public void Read()
    {
        // Arrange
        var testObject = new TestUriObject()
        {
            Uri = new(Uri, UriKind)
        };

        var json = $$"""
        {
          "Uri": "{{Uri}}"
        }
        """;

        // Act
        var deserialized = JsonSerializer.Deserialize<TestUriObject>(json, SerializerOptions);

        // Assert
        deserialized.Should().BeEquivalentTo(testObject);
    }

    [Fact]
    public void Write()
    {
        // Arrange
        var testObject = new TestUriObject()
        {
            Uri = new(Uri, UriKind)
        };

        var json = $$"""
        {
          "Uri": "{{Uri}}"
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
        var testObject = new TestUriObject()
        {
            Uri = null
        };

        const string json = $$"""
        {
          "Uri": null
        }
        """;

        // Act
        var deserialized = JsonSerializer.Deserialize<TestUriObject>(json, SerializerOptions);

        // Assert
        deserialized.Should().BeEquivalentTo(testObject);
    }

    [Fact]
    public void WriteNull()
    {
        // Arrange
        var testObject = new TestUriObject()
        {
            Uri = null
        };

        const string json = $$"""
        {
          "Uri": null
        }
        """;

        // Act
        var deserialized = JsonSerializer.Serialize(testObject, SerializerOptions);

        // Assert
        deserialized.Should().Be(json);
    }
}
