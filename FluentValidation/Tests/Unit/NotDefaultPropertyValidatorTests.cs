using FluentAssertions;
using FluentValidation;
using System.Net;
using Woody230.FluentValidation.Validators.Property;
using Xunit;

namespace Woody230.FluentValidation.Tests.Unit;

/// <summary>
/// Represents tests for the <see cref="NotDefaultPropertyValidator{T, TProperty}"/>.
/// </summary>
public class NotDefaultPropertyValidatorTests
{
    /// <summary>
    /// Verifies that a string is corrected validated.
    /// </summary>
    [Theory]
    [InlineData(null, false)]
    [InlineData("", true)]
    [InlineData("Foo", true)]
    public void String(string input, bool expected)
    {
        // Arrange
        var validator = new NotDefaultPropertyValidator<object, string>();

        // Act
        var isValid = validator.IsValid(new ValidationContext<object>(new object()), input);

        // Assert
        isValid.Should().Be(expected);
    }

    /// <summary>
    /// Verifies that an enum is corrected validated.
    /// </summary>
    [Theory]
    [InlineData((HttpStatusCode)0, false)]
    [InlineData(HttpStatusCode.Continue, true)]
    [InlineData(HttpStatusCode.Redirect, true)]
    [InlineData(HttpStatusCode.OK, true)]
    [InlineData(HttpStatusCode.NoContent, true)]
    [InlineData(HttpStatusCode.BadGateway, true)]
    [InlineData(HttpStatusCode.BadRequest, true)]
    [InlineData(HttpStatusCode.Forbidden, true)]
    [InlineData(HttpStatusCode.NotFound, true)]
    [InlineData(HttpStatusCode.InternalServerError, true)]
    public void Enum(HttpStatusCode input, bool expected)
    {
        // Arrange
        var validator = new NotDefaultPropertyValidator<object, HttpStatusCode>();

        // Act
        var isValid = validator.IsValid(new ValidationContext<object>(new object()), input);

        // Assert
        isValid.Should().Be(expected);
    }
}
