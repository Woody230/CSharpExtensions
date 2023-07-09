using FluentValidation;
using Woody230.FluentValidation.Validators.Model;
using Woody230.FluentValidation.Validators.Property;
using Woody230.FluentValidation.Web.Models;

namespace Woody230.FluentValidation.Web.Validators;

/// <inheritdoc/>
public class WeatherForecastValidator : NullSafeModelValidator<WeatherForecast>
{
    /// <inheritdoc/>
    public WeatherForecastValidator()
    {
        RuleFor(wf => wf.OptionalEvent).SetValidator(new EventValidator());
        RuleFor(wf => wf.RequiredEvent).Required().SetValidator(new EventValidator());
        RuleFor(wf => wf.OptionalEvents).ForEach(wf => wf.SetValidator(new EventValidator()));
        RuleFor(wf => wf.RequiredEvents).Required().ForEach(wf => wf.SetValidator(new EventValidator()));
        RuleFor(wf => wf.TemperatureC).GreaterThan(0);
    }
}
