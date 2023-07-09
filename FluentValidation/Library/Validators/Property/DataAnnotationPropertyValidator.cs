﻿using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Woody230.FluentValidation.Resources;

namespace Woody230.FluentValidation.Validators.Property;

/// <summary>
/// Validates a <typeparamref name="TProperty"/> using a <see cref="ValidationAttribute"/>.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
/// <typeparam name="TProperty">The type of property.</typeparam>
public sealed class DataAnnotationPropertyValidator<T, TProperty> : FriendlyPropertyValidator<T, TProperty>
{
    private readonly ValidationAttribute _attribute;
    private const string Result = "Result";

    /// <summary>
    /// Initializes a new instance of the <see cref="DataAnnotationPropertyValidator{T, TProperty}"/>.
    /// </summary>
    /// <param name="attribute">The data annotation.</param>
    public DataAnnotationPropertyValidator(ValidationAttribute attribute)
    {
        _attribute = attribute;
    }

    /// <inheritdoc/>
    protected override ErrorMessageTemplateBuilder BuildDefaultErrorMessage(string errorCode)
    {
        return new ErrorMessageTemplateBuilder().AppendPlaceholder(Result);
    }

    /// <summary>
    /// Validates using a data annotation.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="value">The value.</param>
    /// <returns>True if the data annotation result is valid, otherwise false.</returns>
    protected override bool IsPropertyValid(ValidationContext<T> context, TProperty value)
    {
        var result = _attribute.GetValidationResult(value, new ValidationContext(context.InstanceToValidate!));
        if (result == null || result == ValidationResult.Success)
        {
            return true;
        }

        context.MessageFormatter.AppendArgument(Result, result.ErrorMessage);
        return false;
    }
}
