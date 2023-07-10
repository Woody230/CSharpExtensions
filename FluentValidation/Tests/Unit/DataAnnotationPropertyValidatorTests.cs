using FluentAssertions;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Woody230.FluentValidation.Validators.Property;
using Xunit;

namespace Woody230.FluentValidation.Tests.Unit;

/// <summary>
/// Represents tests for the <see cref="DataAnnotationPropertyValidator{T, TProperty}"/>.
/// </summary>
public class DataAnnotationPropertyValidatorTests
{
    /// <summary>
    /// Verifies that the result is dependent on the data annotation, excluding null for allowing an optional validation.
    /// </summary>
    [Theory]
    [InlineData(null, true)]
    [InlineData("", false)]
    [InlineData("Foo", true)]
    public void RequiredDataAnnotation(string input, bool expected)
    {
        // Arrange
        var validator = new DataAnnotationPropertyValidator<object, string>(new RequiredAttribute());

        // Act
        var isValid = validator.IsValid(new ValidationContext<object>(new object()), input);

        // Assert
        isValid.Should().Be(expected);
    }
}
