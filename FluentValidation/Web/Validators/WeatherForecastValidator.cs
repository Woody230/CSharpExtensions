using FluentValidation;
using Woody230.FluentValidation.Validators;
using Woody230.FluentValidation.Validators.Property.Extensions;
using Woody230.FluentValidation.Web.Models;

namespace Woody230.FluentValidation.Web.Validators;

/// <inheritdoc/>
public class WeatherForecastValidator : FriendlyValidator<WeatherForecast>
{
    /// <inheritdoc/>
    public WeatherForecastValidator()
    {
        RuleFor(wf => wf.OptionalEvent).SetValidator(new EventValidator());
        RuleFor(wf => wf.RequiredEvent).Required().SetValidator(new EventValidator());
        RuleFor(wf => wf.Events).Required().ForEach(wf => wf.SetValidator(new EventValidator()));
        RuleFor(wf => wf.TemperatureC).GreaterThan(0);
    }
}
