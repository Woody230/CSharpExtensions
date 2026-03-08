using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;
using Woody230.BindableEnum.Models;

namespace Woody230.BindableEnum.Filters;

/// <summary>
/// Represents a filter for applying the enumerations to the schema of a bindable enum.
/// </summary>
public class BindableEnumSchemaFilter : ISchemaFilter
{
    /// <inheritdoc/>
    public void Apply(IOpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsGenericType)
        {
            return;
        }

        var genericType = context.Type.GetGenericTypeDefinition();
        if (genericType != typeof(IBindableEnum<>) && genericType != typeof(BindableEnum<>))
        {
            return;
        }

        var genericArguments = context.Type.GetGenericArguments();
        if (genericArguments.Length == 0)
        {
            throw new Exception("Expected the bindable enum to have a generic argument.");
        }

        var enumType = genericArguments[0];
        if (schema is not OpenApiSchema implementationSchema)
        {
            return;
        }

        implementationSchema.AllOf = [GetOrCreateEnumSchema()];
        implementationSchema.Type = null;

        IOpenApiSchema GetOrCreateEnumSchema()
        {
            if (context.SchemaRepository.TryLookupByType(enumType, out var referenceSchema))
            {
                return referenceSchema;
            }
            else
            {
                return context.SchemaGenerator.GenerateSchema(enumType, context.SchemaRepository);
            }
        }
    }
}
