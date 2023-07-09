![](https://img.shields.io/github/license/Woody230/CSharpExtensions)
[![](https://img.shields.io/nuget/v/Woody230.FluentValidation)](https://www.nuget.org/packages/Woody230.FluentValidation)

# FluentValidation

Extensions for the [FluentValidation](https://github.com/FluentValidation/FluentValidation) library.

# Validators

## Model Validators

| Name | Description | 
| --- | --- |
| NullSafeModelValidator | Base validator that adds an error to the result instead of throwing an exception when the model is null. |

## Property Validators
| Name | Description | 
| --- | --- |
| DataAnnotationPropertyValidator | Validates through the use of a ValidationAttribute data annotation. |
| ExtensiblePropertyValidator | Base validator that automatically sets the name of the validator to the name of the class without the generic type parameters. Builds a default error message that prepends the property name. |
| NotDefaultPropertyValidator | Validates that the property is not null or a default value. |
| OptionalPropertyValidator | Automatically validates a null value as valid. A required value can separately be designated using the `Required` or `NotNull` extension. |


# Error Message Template Builder
StringBuilder wrapper for creating an error message.

Includes methods for appending/inserting/prepending placeholders by only specifying the name, which will automatically include the curly brackets around it.
There are also specific methods for the `PropertyName` and `PropertyValue` placeholders.

There are implicit conversions between a string and an `ErrorMessageTemplateBuilder` which can be used when overriding the `BuildDefaultErrorMessage` method of an `ExtensiblePropertyValidator`.
```c#
protected override ErrorMessageTemplateBuilder BuildDefaultErrorMessage(string errorCode)
{
    return "must not be null";
}

protected override ErrorMessageTemplateBuilder BuildDefaultErrorMessage(string errorCode)
{
    return new ErrorMessageTemplateBuilder
        .AppendPlaceholder("Foo")
        .Append(" ")
        .AppendPlaceholder("Bar")
        .Append(" ")
        .AppendPropertyValue();
}
```