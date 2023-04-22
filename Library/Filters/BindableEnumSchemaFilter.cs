using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using Woody230.BindableEnum.Models;

namespace Woody230.BindableEnum.Filters
{
    /// <summary>
    /// Represents a filter for applying the enumerations to the schema of a bindable enum.
    /// </summary>
    public class BindableEnumSchemaFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (!context.Type.IsGenericType)
            {
                return;
            }

            var actualGenericType = context.Type.GetGenericTypeDefinition();
            var genericBindableEnum = typeof(BindableEnum<>);
            if (actualGenericType != genericBindableEnum)
            {
                return;
            }

            var genericArguments = context.Type.GetGenericArguments();
            if (genericArguments.Length == 0)
            {
                throw new Exception("Expected the bindable enum to have a generic argument.");
            }

            static IOpenApiAny ToString(Enum @enum) => new OpenApiString(@enum.GetDisplayName());
            schema.Enum = genericArguments[0].GetEnumValues().Cast<Enum>().Select(ToString).ToList();
        }
    }
}
