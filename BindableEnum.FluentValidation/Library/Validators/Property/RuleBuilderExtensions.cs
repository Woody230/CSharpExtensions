using FluentValidation;
using Woody230.BindableEnum.Models;

namespace Woody230.BindableEnum.FluentValidation.Validators.Property;

/// <summary>
/// Represents extensions for the <see cref="IRuleBuilder{T, TProperty}"/>.
/// </summary>
public static class RuleBuilderExtensions
{
    /// <summary>
    /// Applies the <see cref="BindableEnumPropertyValidator{T, TProperty}"/>.
    /// </summary>
    /// <typeparam name="T">The type of model.</typeparam>
    /// <typeparam name="TProperty">The type of property.</typeparam>
    /// <param name="ruleBuilder">The rule builder.</param>
    /// <returns>The rule builder options.</returns>
    public static IRuleBuilderOptions<T, TProperty> BindedEnum<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder) where TProperty: IBindableEnum
    {
        var validator = new BindableEnumPropertyValidator<T, TProperty>();
        return ruleBuilder.SetValidator(validator);
    }
}
