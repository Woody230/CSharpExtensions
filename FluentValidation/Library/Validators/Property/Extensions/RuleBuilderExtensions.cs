using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Woody230.FluentValidation.Validators.Property.Extensions;

/// <summary>
/// Represents extensions for the <see cref="IRuleBuilder{T, TProperty}"/>.
/// </summary>
public static class RuleBuilderExtensions
{
    /// <summary>
    /// Applies the <see cref="DataAnnotationPropertyValidator{T, TProperty}"/> with the given <paramref name="attribute"/>
    /// </summary>
    /// <typeparam name="T">The type of model.</typeparam>
    /// <typeparam name="TProperty">The type of property.</typeparam>
    /// <typeparam name="TValidator">The type of validator.</typeparam>
    /// <param name="ruleBuilder">The rule builder.</param>
    /// <param name="attribute">The data annotation validation attribute.</param>
    /// <returns>The rule builder options.</returns>
    public static IRuleBuilderOptions<T, TProperty> DataAnnotation<T, TProperty, TValidator>(
        this IRuleBuilder<T, TProperty> ruleBuilder,
        ValidationAttribute attribute
    ) {
        var validator = new DataAnnotationPropertyValidator<T, TProperty>(attribute);
        return ruleBuilder.SetValidator(validator);
    }

    /// <summary>
    /// Applies the <see cref="NonDefaultPropertyValidator{T, TProperty}"/>.
    /// </summary>
    /// <typeparam name="T">The type of model.</typeparam>
    /// <typeparam name="TProperty">The type of property.</typeparam>
    /// <param name="ruleBuilder">The rule builder.</param>
    /// <returns>The rule builder options.</returns>
    public static IRuleBuilderOptions<T, TProperty> NonDefault<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
    {
        var validator = new NonDefaultPropertyValidator<T, TProperty>();
        return ruleBuilder.SetValidator(validator);
    }
}

