using FluentValidation.Validators;
using Woody230.FluentValidation.Resources;

namespace Woody230.FluentValidation.Validators.Property;

/// <summary>
/// Validates a <typeparamref name="TProperty"/> within the context of a <typeparamref name="T"/>.
/// </summary>
public abstract class ExtensiblePropertyValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    /// <inheritdoc/>
    public override string Name
    {
        get
        {
            var name = GetType().Name;
            return name[..name.IndexOf('`')];
        }
    }

    /// <summary>
    /// Gets the default error message for this validator.
    /// The message includes the name of the property at the beginning.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <returns>The default error message.</returns>
    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return BuildDefaultErrorMessage(errorCode).Prepend("'").PrependPropertyName().Prepend("'");
    }

    /// <summary>
    /// Builds the default error message for this validator.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <returns>The error message builder.</returns>
    protected abstract ErrorMessageTemplateBuilder BuildDefaultErrorMessage(string errorCode);
}
