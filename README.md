![](https://img.shields.io/github/v/release/Woody230/BindableEnum)
[![](https://img.shields.io/nuget/v/BindableEnum)](https://www.nuget.org/packages?q=BindableEnum)
![](https://img.shields.io/github/license/Woody230/BindableEnum)

# BindableEnum
Provides an enumeration wrapper that holds whether binding from the original string is successful.

This is useful when model state validation needs to be postponed to sometime after the automatic validation that is provided by an ApiController.

# Setup

## Program.cs
Configure the `BindableEnumSwaggerGenOptions` on the service collection.

```c#
using BindableEnum.Library.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureOptions<BindableEnumSwaggerGenOptions>();
```

This will map the `BindableEnum` generic type definition with an OpenApiSchema type of string.

Also, the `BindableEnumSchemaFilter` is applied in order to add the enumerations to the OpenApiSchema.

## Model
When declaring your bindable enumeration, you can use the `BindableEnumAttribute` to validate that the enumeration has been successfully binded.

```c#
using BindableEnum.Library.Models;
using BindableEnum.Library.Validation;
using System;

public record WeatherForecast
{
    [BindableEnum]
    public BindableEnum<DayOfWeek> DayOfWeek { get; set; }
}    
```