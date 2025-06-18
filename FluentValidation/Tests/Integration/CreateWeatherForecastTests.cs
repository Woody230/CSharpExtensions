using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using Woody230.FluentValidation.Web.Models;

namespace Woody230.FluentValidation.Tests.Integration;

/// <summary>
/// Represents tests for the <see cref="WeatherForecastController"/> related to creating a new weather forecast.
/// </summary>
public class CreateWeatherForecastTests(WebApplicationFactory<Program> factory) : IntegrationTests(factory)
{
    /// <summary>
    /// The serializer options.
    /// </summary>
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never
    };

    /// <summary>
    /// Verifies that validation passes when a valid model is used.
    /// </summary>
    [Fact]
    public async Task Create_WithValidForecast_ReturnsOk()
    {
        // Arrange
        var forecast = new WeatherForecast()
        {
            TemperatureC = 32,
            RequiredEvent = new Event()
            {
                Description = "* Foo",
                Name = "* Bar"
            },
            RequiredEvents =
            [
                new Event()
                {
                    Description = "* Fizz",
                    Name = "* Buzz"
                }
            ]
        };

        var request = CreateRequest(forecast);

        // Act
        var response = await HttpClient.SendAsync(request);

        // Assert
        using var scope = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();
        scope.AddReportable("Content", content);

        var model = JsonSerializer.Deserialize<WeatherForecast>(content, _options);
        model.Should().BeEquivalentTo(forecast);
    }

    /// <summary>
    /// Verifies that validation fails when an invalid model is used.
    /// </summary>
    [Fact]
    public async Task Create_WithInvalidForecast_ReturnsBadRequest()
    {
        // Arrange
        var forecast = new WeatherForecast()
        {
            TemperatureC = -1,
            OptionalEvent = new Event(),
            RequiredEvent = new Event()
            {
                Description = "Foo",
                Name = "* Bar"
            },
            RequiredEvents =
            [
                new Event()
                {
                    Description = "* 1",
                    Name = "* 2"
                },
                null,
                new Event()
                {
                    Description = "* Fizz",
                    Name = "Buzz"
                },
                null
            ],
            OptionalEvents =
            [
                null,
                new Event()
                {
                    Description = "* 1",
                    Name = "* 2"
                },
                new Event()
                {
                    Description = "* 5",
                    Name = "678"
                },
                null
            ]
        };

        var request = CreateRequest(forecast);

        // Act
        var response = await HttpClient.SendAsync(request);

        // Assert
        await AssertBadResponse(response, "[OptionalEvent.Description] 'Description' must not be empty.\r\n[RequiredEvent.Description] 'Description' must start with *\r\n[OptionalEvents[2].Name] 'Name' must start with *\r\n[RequiredEvents[2].Name] 'Name' must start with *\r\n[TemperatureC] 'Temperature C' must be greater than '0'.");
    }

    /// <summary>
    /// Verifies that validation fails when an invalid model is used.
    /// </summary>
    [Fact]
    public async Task Create_WithEmptyForecast_ReturnsBadRequest()
    {
        // Arrange
        var forecast = new WeatherForecast();
        var request = CreateRequest(forecast);

        // Act
        var response = await HttpClient.SendAsync(request);

        // Assert
        await AssertBadResponse(response, "[RequiredEvent] 'Required Event' must not be empty.\r\n[RequiredEvents] 'Required Events' must not be empty.\r\n[TemperatureC] 'Temperature C' must be greater than '0'.");
    }

    /// <summary>
    /// Verifies that validation fails when an invalid model is used.
    /// </summary>
    [Fact]
    public async Task Create_WithNullForecast_ReturnsBadRequest()
    {
        // Arrange
        var request = CreateRequest(null);

        // Act
        var response = await HttpClient.SendAsync(request);

        // Assert
        await AssertBadResponse(response, "[$] Model is null.");
    }

    private async Task AssertBadResponse(HttpResponseMessage response, string expectedContent)
    {
        using var scope = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadAsStringAsync();
        scope.AddReportable("Content", content);

        content.Should().Be(expectedContent);
    }

    /// <summary>
    /// Creates the request.
    /// </summary>
    /// <param name="dayOfWeek">The day of the week.</param>
    /// <returns>The request.</returns>
    private HttpRequestMessage CreateRequest(WeatherForecast forecast)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "WeatherForecast");
        request.Content = new StringContent(JsonSerializer.Serialize(forecast, _options));
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return request;
    }
}