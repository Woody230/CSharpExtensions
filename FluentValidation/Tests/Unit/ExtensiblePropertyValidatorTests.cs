using FluentAssertions;
using FluentValidation.Validators;
using Woody230.FluentValidation.Validators.Property;
using Woody230.FluentValidation.Web.Models;
using Woody230.FluentValidation.Web.Validators;
using Xunit;

namespace Woody230.FluentValidation.Tests.Unit;

/// <summary>
/// Represents tests for the <see cref="ExtensionPropertyValidator"/>.
/// </summary>
public class ExtensiblePropertyValidatorTests
{
    /// <summary>
    /// Verifies that the error message is formatted correctly.
    /// </summary>
    [Fact]
    public void BuildsErrorMessage()
    {
        // Arrange 
        IPropertyValidator validator = new EventStringValidator();

        // Act
        var message = validator.GetDefaultMessageTemplate(null);

        // Assert
        message.Should().Be("'{PropertyName}' must start with *");
    }

    /// <summary>
    /// Verifies that generic types are removed from the name of the validator.
    /// </summary>
    [Fact]
    public void SetsName()
    {
        // Arrange
        IPropertyValidator noGenerics = new EventStringValidator();
        IPropertyValidator withGenerics = new NotDefaultPropertyValidator<WeatherForecast, string>();

        // Act
        var noGenericsName = noGenerics.Name;
        var withGenericsName = withGenerics.Name;

        // Assert
        noGenericsName.Should().Be("EventStringValidator");
        withGenericsName.Should().Be("NotDefaultPropertyValidator");
    }
}
