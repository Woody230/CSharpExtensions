using FluentAssertions;
using FluentValidation;
using Woody230.BindableEnum.FluentValidation.Validators.Property;
using Woody230.BindableEnum.Models;
using Xunit;

namespace Woody230.BindableEnum.FluentValidation.Tests.Validator.Property;

/// <summary>
/// Represents tests for the <see cref="BindableEnumPropertyValidator{T, TProperty}"/>
/// </summary>
public class BindableEnumPropertyValidatorTests
{
    [Theory]
    [InlineData(null, true)]
    [InlineData("", false, "'Enum' value `` must be one of the following Color values: Red, Blue")]
    [InlineData("Red", true)]
    [InlineData("Blue", true)]
    [InlineData("Green", false, "'Enum' value `Green` must be one of the following Color values: Red, Blue")]
    public void BindedEnum_IsValid(string @enum, bool expected, string message = null)
    {
        // Arrange
        var validator = new WrapperValidator();
        var wrapper = new Wrapper() { Enum = @enum == null ? null : new BindableEnum<Color>(@enum) };

        // Act
        var result = validator.Validate(wrapper);

        // Assert
        result.IsValid.Should().Be(expected);
        
        if (expected)
        {
            result.Errors.Should().BeEmpty();
        }
        else
        {
            result.Errors.Should().HaveCount(1);
            var error = result.Errors[0];
            error.PropertyName.Should().Be("Enum");
            error.ErrorMessage.Should().Be(message);
        }
    }

    private record Wrapper
    {
        public BindableEnum<Color> Enum { get; init; }
    }

    private enum Color
    {
        Red,
        Blue,
    }

    private class WrapperValidator: AbstractValidator<Wrapper>
    {
        public WrapperValidator() 
        {
            RuleFor(wrapper => wrapper.Enum).BindedEnum();
        }
    }
}
