using FluentAssertions;
using System;
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
    /// Verifies that the implicit conversions to/from a string are valid.
    /// </summary>
    [Fact]
    public void StringImplicitConversions()
    {
        ErrorMessageTemplateBuilder builder = "foo bar";
        builder.ToString().Should().Be("foo bar");

        string str = builder;
        str.Should().Be("foo bar");

        string nullStr = null;
        builder = nullStr;
        builder.ToString().Should().Be(string.Empty);

        builder = null;
        this.Invoking(_ => nullStr = builder).Should().Throw<NullReferenceException>();
    }
}
