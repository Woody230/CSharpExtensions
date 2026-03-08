using FluentAssertions.Execution;
using FluentAssertions.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System.Net;
using Woody230.BindableEnum.Tests.Properties;

namespace Woody230.BindableEnum.Tests.Integration;

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
        var expectedJson = JObject.Parse(Resources.swagger);
        json.Should().BeEquivalentTo(expectedJson);
    }
}
