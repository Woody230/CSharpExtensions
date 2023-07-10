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

    /// <summary>
    /// Verifies that the extension applies the validator.
    /// </summary>
    [Fact]
    public void Extension()
    {
        // Arrange
        var validator = new WrapperValidator();

        // Act
        var result = validator.Validate(new Wrapper());

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(2);
        result.Errors[0].ErrorMessage.Should().Be("'Enum' must not be null or defaulted");
        result.Errors[1].ErrorMessage.Should().Be("'Nullable Enum' must not be null or defaulted");
    }

    private record Wrapper
    {
        public Color Enum { get; init; }
        public Color? NullableEnum { get; init; }
    }

    private enum Color
    {
        Red = 1,
        Blue = 2,
    }

    private class WrapperValidator : AbstractValidator<Wrapper>
    {
        public WrapperValidator()
        {
            RuleFor(wrapper => wrapper.Enum).NotDefault();
            RuleFor(wrapper => wrapper.NullableEnum).NotDefault();
        }
    }
}
