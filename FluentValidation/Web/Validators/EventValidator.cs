using Woody230.FluentValidation.Validators.Model;
using Woody230.FluentValidation.Validators.Property;
using Woody230.FluentValidation.Web.Models;

namespace Woody230.FluentValidation.Web.Validators;

/// <inheritdoc/>
public class EventValidator: NullSafeModelValidator<Event>
{
    /// <inheritdoc/>
    public EventValidator()
    {
        RuleFor(e => e.Name).SetValidator(new EventStringValidator());
        RuleFor(e => e.Description).Required().SetValidator(new EventStringValidator());
    }
}
