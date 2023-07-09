using FluentValidation;
using FluentValidation.Validators;

namespace Woody230.FluentValidation.Validators.Property;

/// <summary>
/// <para>
/// Validates a <typeparamref name="TProperty"/> within the context of a <typeparamref name="T"/>.
/// </para>
/// <para>
/// When the property is null, then the property is considered valid.
/// This allows the reuse of logic within an optional/required context where a <see cref="NotNullValidator{T, TProperty}"/> is used if the value should be considered required.
/// </para>
/// </summary>
public abstract class OptionalPropertyValidator<T, TProperty> : ExtensiblePropertyValidator<T, TProperty>
{
    /// <summary>
    /// Validates whether the <paramref name="value"/> is valid.
    /// Null values are automatically considered valid and should be handled separately with a <see cref="NotNullValidator{T, TProperty}"/> if the value is required.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="value">The nullable value.</param>
    /// <returns>True if the value is null or valid, otherwise false.</returns>
    public override bool IsValid(ValidationContext<T> context, TProperty? value)
    {
        if (value == null)
        {
            return true;
        }

        return IsPropertyValid(context, value);
    }

    /// <summary>
    /// Validates whether the <paramref name="value"/> is valid.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="value">The value.</param>
    /// <returns>True if valid, otherwise false.</returns>
    protected abstract bool IsPropertyValid(ValidationContext<T> context, TProperty value);
}
