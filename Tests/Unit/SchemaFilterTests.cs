using FluentAssertions;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using Woody230.BindableEnum.Filters;
using Woody230.BindableEnum.Models;
using Xunit;

namespace Woody230.BindableEnum.Tests.Unit
{
    /// <summary>
    /// Represents tests for the <see cref="BindableEnumSchemaFilter"/>.
    /// </summary>
    public class SchemaFilterTests
    {
        /// <summary>
        /// The expected enumerations.
        /// </summary>
        private static readonly IEnumerable<IOpenApiAny> _enums = new List<OpenApiString>()
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
        /// Verifies that when the schema filter is applied to a <see cref="IBindableEnum{T}"/>, then the associated enumerations are documented.
        /// </summary>
        [Fact]
        public void Apply_ToInterface_AddsEnumerations()
        {
            // Arrange
            var type = typeof(IBindableEnum<DayOfWeek>);

            var schema = new OpenApiSchema();
            var context = new SchemaFilterContext(type, null, null);

            // Act
            new BindableEnumSchemaFilter().Apply(schema, context);

            // Assert
            schema.Enum.Should().BeEquivalentTo(_enums);
        }

        /// <summary>
        /// Verifies that when the schema filter is applied to a <see cref="BindableEnum{T}"/>, then the associated enumerations are documented.
        /// </summary>
        [Fact]
        public void Apply_ToImplementation_AddsEnumerations()
        {
            // Arrange
            var type = typeof(BindableEnum<DayOfWeek>);

            var schema = new OpenApiSchema();
            var context = new SchemaFilterContext(type, null, null);

            // Act
            new BindableEnumSchemaFilter().Apply(schema, context);

            // Assert
            schema.Enum.Should().BeEquivalentTo(_enums);
        }
    }
}
