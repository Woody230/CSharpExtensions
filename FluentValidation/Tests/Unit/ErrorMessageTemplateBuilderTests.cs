using FluentAssertions;
using Woody230.FluentValidation.Resources;
using Xunit;

namespace Woody230.FluentValidation.Tests.Unit;

/// <summary>
/// Represents tests for the <see cref="ErrorMessageTemplateBuilder"/>.
/// </summary>
public class ErrorMessageTemplateBuilderTests
{
    /// <summary>
    /// Verifies that placeholders are correctly added.
    /// </summary>
    [Fact]
    public void BuildsPlaceholders()
    {
        // Arrange
        var builder = new ErrorMessageTemplateBuilder();

        // Act
        var str = builder.Append("foo").Append(" ").AppendPlaceholder("fizz").AppendPropertyName().AppendLine().AppendPropertyValue().AppendPlaceholder("Buzz").ToString();

        // Assert
        str.Should().Be("foo {fizz}{PropertyName}\r\n{PropertyValue}{Buzz}");
    }

    /// <summary>
    /// Verifies that the implicit conversions to a string is valid.
    /// </summary>
    [Fact]
    public void BuilderToStringConversion()
    {
        ErrorMessageTemplateBuilder builder = "foo bar";
        builder.ToString().Should().Be("foo bar");

        string str = builder;
        str.Should().Be("foo bar");
    }

    /// <summary>
    /// Verifies that the implicit conversions from a string is valid.
    /// </summary>
    [Fact]
    public void StringToBuilderConversion()
    {
        string str = null;
        ErrorMessageTemplateBuilder builder = str;
        builder.ToString().Should().Be(string.Empty);

        str = "foo";
        builder = str;
        builder.ToString().Should().Be("foo");
    }

    /// <summary>
    /// Verifies that the implicit conversions to a string is valid.
    /// </summary>
    [Fact]
    public void NullableBuilderToStringConversion()
    {
        string str = string.Empty;
        ErrorMessageTemplateBuilder builder = null;
        this.Invoking(_ => str = builder).Should().Throw<NullReferenceException>();
    }
}
