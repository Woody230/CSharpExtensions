using FluentValidation;
using Woody230.FluentValidation.Resources;
using Woody230.FluentValidation.Validators.Property;
using Woody230.FluentValidation.Web.Models;

namespace Woody230.FluentValidation.Web.Validators;

/// <inheritdoc/>
public class EventStringValidator : OptionalPropertyValidator<Event, string>
{
    /// <inheritdoc/>
    protected override ErrorMessageTemplateBuilder BuildDefaultErrorMessage(string errorCode)
    {
        return "must start with *";
    }

    /// <inheritdoc/>
    protected override bool IsPropertyValid(ValidationContext<Event> context, string value)
    {
        return value!.StartsWith('*');
    }
}
