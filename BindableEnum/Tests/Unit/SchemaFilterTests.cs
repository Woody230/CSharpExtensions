using FluentAssertions;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json;
using Woody230.BindableEnum.Filters;
using Woody230.BindableEnum.Models;
using Woody230.BindableEnum.Options;
using Xunit;

namespace Woody230.BindableEnum.Tests.Unit;

/// <summary>
/// Represents tests for the <see cref="BindableEnumSchemaFilter"/>.
/// </summary>
public class SchemaFilterTests
{
    /// <summary>
    /// The expected enumerations.
    /// </summary>
    private static readonly IList<IOpenApiAny> _enums = new List<IOpenApiAny>()
    {
        new OpenApiString("Sunday"),
        new OpenApiString("Monday"),
        new OpenApiString("Tuesday"),
        new OpenApiString("Wednesday"),
        new OpenApiString("Thursday"),
        new OpenApiString("Friday"),
        new OpenApiString("Saturday"),
    };

    /// <summary>
    /// The expected schema.
    /// </summary>
    private static readonly OpenApiSchema _schema = new()
    {
        Type = "string",
        Reference = new OpenApiReference()
        {
            Id = "DayOfWeek",
            Type = ReferenceType.Schema
        }
    };

    /// <summary>
    /// The schema generator.
    /// </summary>
    private static readonly SchemaGenerator _schemaGenerator = new(new SchemaGeneratorOptions(), new JsonSerializerDataContractResolver(new JsonSerializerOptions()));

    /// <summary>
    /// The schema repository.
    /// </summary>
    private static readonly SchemaRepository _schemaRepository = new SchemaRepository();

    /// <summary>
    /// Verifies that when the schema filter is applied to a <see cref="IBindableEnum{T}"/>, then the associated enumerations are documented.
    /// </summary>
    [Fact]
    public void ApplyToInterface_AddsEnumerations()
    {
        // Arrange
        var type = typeof(IBindableEnum<DayOfWeek>);

        var schema = CreateSchema(typeof(IBindableEnum<>));
        var context = new SchemaFilterContext(type, _schemaGenerator, _schemaRepository);

        // Act
        new BindableEnumSchemaFilter().Apply(schema, context);

        // Assert
        schema.Should().BeEquivalentTo(_schema);
    }

    /// <summary>
    /// Verifies that when the schema filter is applied to a <see cref="BindableEnum{T}"/>, then the associated enumerations are documented.
    /// </summary>
    [Fact]
    public void ApplyToImplementation_AddsEnumerations()
    {
        // Arrange
        var type = typeof(BindableEnum<DayOfWeek>);

        var schema = CreateSchema(typeof(BindableEnum<>));
        var context = new SchemaFilterContext(type, _schemaGenerator, _schemaRepository);

        // Act
        new BindableEnumSchemaFilter().Apply(schema, context);

        // Assert
        schema.Should().BeEquivalentTo(_schema);
    }

    /// <summary>
    /// Creates the schema from the swagger gen options.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The schema.</returns>
    private OpenApiSchema CreateSchema(Type type)
    {
        var swaggerOptions = new SwaggerGenOptions();
        new BindableEnumSwaggerGenOptions().Configure(swaggerOptions);

        var mapping = swaggerOptions.SchemaGeneratorOptions.CustomTypeMappings;
        mapping.Should().ContainKey(type);
        return mapping[type]();
    }
}
