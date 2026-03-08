using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Woody230.FluentValidation.Tests.Integration;

/// <summary>
/// Represents tests for the swagger.json
/// </summary>
public class SwaggerTests(WebApplicationFactory<Program> factory) : IntegrationTests(factory)
{
    /// <summary>
    /// Verifies that the swagger.json is the expected content.
    /// </summary>
    [Fact]
    public async Task GetSwaggerJson()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "swagger/v1/swagger.json");

        // Act
        var response = await HttpClient.SendAsync(request);

        // Assert
        using var scope = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();
        AssertionChain.GetOrCreate().WithReportable("Content", () => content);

        var json = JObject.Parse(content);
        var expectedJson = JObject.Parse(Properties.Resources.swagger);
        json.Should().BeEquivalentTo(expectedJson);
    }
}