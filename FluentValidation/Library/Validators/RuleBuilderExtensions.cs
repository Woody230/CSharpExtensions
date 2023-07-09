using FluentValidation;

namespace Woody230.FluentValidation.Validators;

/// <summary>
/// Represents extensions for the <see cref="IRuleBuilder{T, TProperty}"/>.
/// </summary>
public static class RuleBuilderExtensions
{
    /// <summary>
    /// Applies the <paramref name="validator"/> when the model is not null, avoiding the requirement that the property has to exist.
    /// </summary>
    /// <typeparam name="T">The type of model.</typeparam>
    /// <typeparam name="TProperty">The type of property.</typeparam>
    /// <typeparam name="TValidator">The type of validator.</typeparam>
    /// <param name="ruleBuilder">The rule builder.</param>
    /// <param name="validator">The validator.</param>
    /// <param name="ruleSets">The rule sets.</param>
    /// <returns>The rule builder options.</returns>
    public static IRuleBuilderOptions<T, TProperty> OptionalValidator<T, TProperty, TValidator>(
        this IRuleBuilder<T, TProperty> ruleBuilder,
        TValidator validator,
        params string[] ruleSets
    ) where TValidator : OptionalValidator<TProperty>
    {
        return ruleBuilder.SetValidator(validator, ruleSets).When(model => model != null, ApplyConditionTo.CurrentValidator);
    }
}
