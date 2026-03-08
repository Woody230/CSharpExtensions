using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Woody230.BindableEnum.Filters;
using Woody230.BindableEnum.Models;
using Woody230.BindableEnum.Options;

namespace Woody230.BindableEnum.Tests.Unit;

/// <summary>
/// Represents tests for the <see cref="BindableEnumSchemaFilter"/>.
/// </summary>
public class SchemaFilterTests
{
    /// <summary>
    /// The expected enumerations.
    /// </summary>
    private static readonly IList<string> _enums =
    [
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday",
    ];

    /// <summary>
    /// The expected schema.
    /// </summary>
    private static readonly OpenApiSchema _schema = new()
    {
        AllOf = [
            new OpenApiSchemaReference("DayOfWeek")
        ],
        Description = "Foo Bar Baz"
    };

    /// <summary>
    /// The JSON serializer options.
    /// </summary>
    private readonly JsonSerializerOptions _serializerOptions = new();

    /// <summary>
    /// The schema generator.
    /// </summary>
    private readonly SchemaGenerator _schemaGenerator;

    /// <summary>
    /// The schema repository.
    /// </summary>
    private readonly SchemaRepository _schemaRepository = new();

    public SchemaFilterTests()
    {
        _serializerOptions.Converters.Add(new JsonStringEnumConverter());
        _schemaGenerator = new(new SchemaGeneratorOptions(), new JsonSerializerDataContractResolver(_serializerOptions));
    }

    /// <summary>
    /// Verifies that when the schema filter is applied to a <see cref="IBindableEnum{T}"/>, then the associated enumerations are documented.
    /// </summary>
    [Fact]
    public void ApplyToInterface_AddsEnumerations()
    {
        // Arrange
        _schemaRepository.TryLookupByType(typeof(DayOfWeek), out var _).Should().BeFalse();

        var type = typeof(IBindableEnum<DayOfWeek>);


        var schema = CreateSchema(typeof(IBindableEnum<>));
        var context = new SchemaFilterContext(type, _schemaGenerator, _schemaRepository);

        // Act
        new BindableEnumSchemaFilter().Apply(schema, context);

        // Assert
        schema.Should().BeEquivalentTo(_schema);

        _schemaRepository.TryLookupByType(typeof(DayOfWeek), out var _).Should().BeTrue();

        _schemaRepository.Schemas.TryGetValue(nameof(DayOfWeek), out var dayOfWeekSchema).Should().BeTrue();
        dayOfWeekSchema.Should().BeEquivalentTo(
            new OpenApiSchema()
            {
                Type = JsonSchemaType.String
            },
            options => options.Excluding(schema => schema.Enum)
        );

        dayOfWeekSchema.Enum.Should().AllBeAssignableTo<JsonValue>()
            .Which.Select(jsonValue => jsonValue.TryGetValue<string>(out var value) ? value : null).Should().BeEquivalentTo(_enums, options => options.WithStrictOrdering());
    }

    /// <summary>
    /// Verifies that when the schema filter is applied to a <see cref="BindableEnum{T}"/>, then the associated enumerations are documented.
    /// </summary>
    [Fact]
    public void ApplyToImplementation_AddsEnumerations()
    {
        // Arrange
        _schemaRepository.TryLookupByType(typeof(DayOfWeek), out var _).Should().BeFalse();

        var type = typeof(BindableEnum<DayOfWeek>);

        var schema = CreateSchema(typeof(BindableEnum<>));
        var context = new SchemaFilterContext(type, _schemaGenerator, _schemaRepository);

        // Act
        new BindableEnumSchemaFilter().Apply(schema, context);

        // Assert
        schema.Should().BeEquivalentTo(_schema);

        _schemaRepository.TryLookupByType(typeof(DayOfWeek), out var _).Should().BeTrue();

        _schemaRepository.Schemas.TryGetValue(nameof(DayOfWeek), out var dayOfWeekSchema).Should().BeTrue();
        dayOfWeekSchema.Should().BeEquivalentTo(
            new OpenApiSchema()
            {
                Type = JsonSchemaType.String
            }, 
            options => options.Excluding(schema => schema.Enum)
        );

        dayOfWeekSchema.Enum.Should().AllBeAssignableTo<JsonValue>()
            .Which.Select(jsonValue => jsonValue.TryGetValue<string>(out var value) ? value : null).Should().BeEquivalentTo(_enums, options => options.WithStrictOrdering());
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
        return new OpenApiSchema() { Type = JsonSchemaType.String, Description = "Foo Bar Baz" };
    }
}
