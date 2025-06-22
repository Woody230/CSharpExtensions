using System.Text.Json;
using System.Text.Json.Serialization;

namespace Woody230.Text.Json.Converters.Tests.Unit.Uri;

/// <summary>
/// Represents tests related to a <see cref="JsonConverter{System.Uri}"/>
/// </summary>
public abstract class BaseUriJsonConverterTests<TConverter> : BaseJsonConverterTests where TConverter : JsonConverter<System.Uri>, new()
{
    protected abstract UriKind UriKind { get; }
    protected string Uri => GetUriValidity().First(uri => uri.Value).Key;

    protected BaseUriJsonConverterTests()
    {
        SerializerOptions.Converters.Add(new TConverter());
    }

    public abstract void Read(string uri, bool isValid);

    protected void ReadImpl(string uri, bool isValid)
    {
        // Arrange
        var testObject = isValid ? new TestUriObject() { Uri = new(uri, UriKind) } : null;

        var json = $$"""
        {
          "Uri": "{{uri}}"
        }
        """;

        // Act
        var deserializeAction = () => JsonSerializer.Deserialize<TestUriObject>(json, SerializerOptions);

        // Assert
        if (isValid)
        {
            var deserialized = deserializeAction.Should().NotThrow().Which;
            deserialized.Should().BeEquivalentTo(testObject);
        }
        else
        {
            deserializeAction.Should().Throw<UriFormatException>();
        }
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

    /// <summary>
    /// Gets uris mapped to whether they are valid.
    /// </summary>
    protected abstract IDictionary<string, bool> GetUriValidity();

    public static TheoryData<string, bool> ToTheoryData(IDictionary<string, bool> urls)
    {
        var data = new TheoryData<string, bool>();
        foreach (var (uri, isValid) in urls)
        {
            data.Add(uri, isValid);
        }

        return data;
    }
}
