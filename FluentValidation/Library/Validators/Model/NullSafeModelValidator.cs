using FluentValidation;
using FluentValidation.Results;

namespace Woody230.FluentValidation.Validators.Model;

/// <summary>
/// <para>
/// Validates a <typeparamref name="T"/> in a non-exception based way.
/// </para>
/// <para>
/// When the model is null, then a validation failure is added to the result's errors.
/// This is in contrast to the default behavior of throwing an exception.
/// </para>
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public abstract class NullSafeModelValidator<T> : AbstractValidator<T>
{
    /// <summary>
    /// When the model is null, then a validation failure is added to the result's errors.
    /// This is in constrast to the default behavior of throwing an exception.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="result">The result.</param>
    /// <returns>True if valid, otherwise false.</returns>
    protected override bool PreValidate(ValidationContext<T> context, ValidationResult result)
    {
        if (context.InstanceToValidate == null)
        {
            result.Errors.Add(new ValidationFailure("$", "Model is null."));
            return false;
        }

        return base.PreValidate(context, result);
    }
}
