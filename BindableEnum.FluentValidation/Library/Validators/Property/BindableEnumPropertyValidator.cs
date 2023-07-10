using FluentValidation;
using System;
using System.Linq;
using Woody230.BindableEnum.Models;
using Woody230.FluentValidation.Resources;
using Woody230.FluentValidation.Validators.Property;

namespace Woody230.BindableEnum.FluentValidation.Validators.Property;

/// <summary>
/// Validates that a bindable enum has been successfully binded.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public sealed class BindableEnumPropertyValidator<T, TProperty> : OptionalPropertyValidator<T, TProperty> where TProperty : IBindableEnum
{
    public const string EnumName = "EnumName";
    public const string EnumValues = "EnumValues";

    protected override ErrorMessageTemplateBuilder BuildDefaultErrorMessage(string errorCode)
    {
        return new ErrorMessageTemplateBuilder()
            .Append("value `")
            .AppendPropertyValue()
            .Append("` must be one of the following ")
            .AppendPlaceholder(EnumName)
            .Append(" values: ")
            .AppendPlaceholder(EnumValues);
    }

    protected override bool IsPropertyValid(ValidationContext<T> context, TProperty value)
    {
        if (value.Binded)
        {
            return true;
        }

        var valueType = value.GetType();
        var enumName = valueType.IsGenericType ? valueType.GetGenericArguments()[0].Name : string.Empty;
        var expectedValues = value.Enum.GetType().GetEnumValues().Cast<Enum>().Select(@enum => @enum.ToString());
        context.MessageFormatter.AppendArgument(EnumName, enumName).AppendArgument(EnumValues, string.Join(", ", expectedValues));
        return false;
    }
}
