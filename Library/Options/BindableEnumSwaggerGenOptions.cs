using BindableEnum.Library.Filters;
using BindableEnum.Library.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BindableEnum.Library.Options
{
    /// <summary>
    /// Represents options for configuring a bindable enum.
    /// </summary>
    public class BindableEnumSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        /// <inheritdoc/>
        public void Configure(SwaggerGenOptions options)
        {
            options.SchemaFilter<BindableEnumSchemaFilter>();
            options.MapType(typeof(BindableEnum<>), () => new OpenApiSchema { Type = "string" });
        }
    }
}
