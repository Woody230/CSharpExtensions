using FluentAssertions;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Woody230.FluentValidation.Web.Models;
using Woody230.FluentValidation.Web.Validators;
using Xunit;

namespace Woody230.FluentValidation.Tests.Unit;

/// <summary>
/// Represents tests for the <see cref="FriendlyValidator{T}"/>
/// </summary>
public class FriendlyValidatorTests
{
    /// <summary>
    /// Verifies that when the instance is null, then an error is added instead of being thrown.
    /// </summary>
    [Fact]
    public void NoThrowOnError()
    {
        // Arrange
        var validator = new EventValidator();
        var input = (Event)null;

        // Act
        var result = validator.Validate(input);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors[0].Should().BeEquivalentTo(new ValidationFailure("$", "Model is null."));
    }
}
