using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Woody230.BindableEnum.Filters;
using Woody230.BindableEnum.Models;

namespace Woody230.BindableEnum.Options;

/// <summary>
/// Represents options for configuring a bindable enum.
/// </summary>
public class BindableEnumSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    /// <inheritdoc/>
    public void Configure(SwaggerGenOptions options)
    {
        options.SchemaFilter<BindableEnumSchemaFilter>();
        options.MapType(typeof(IBindableEnum<>), () => new OpenApiSchema { Type = "string" });
        options.MapType(typeof(BindableEnum<>), () => new OpenApiSchema { Type = "string" });
    }
}
