using FluentValidation;
using Woody230.FluentValidation.Validators;
using Woody230.FluentValidation.Validators.Property;
using Woody230.FluentValidation.Web.Models;

namespace Woody230.FluentValidation.Web.Validators;

/// <inheritdoc/>
public class WeatherForecastValidator : OptionalValidator<WeatherForecast>
{
    /// <inheritdoc/>
    public WeatherForecastValidator()
    {
        RuleFor(wf => wf.OptionalEvent).OptionalValidator(new EventValidator());
        RuleFor(wf => wf.RequiredEvent).Required().OptionalValidator(new EventValidator());
        RuleFor(wf => wf.Events).Required().ForEach(wf => wf.OptionalValidator(new EventValidator()));
        RuleFor(wf => wf.TemperatureC).GreaterThan(0);
    }
}
