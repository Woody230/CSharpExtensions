using BindableEnum.Web.Controllers;
using BindableEnum.Web.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace BindableEnum.Tests.Integration
{
    /// <summary>
    /// Represents tests for the <see cref="WeatherForecastController"/> related to creating a new weather forecast.
    /// </summary>
    public class CreateWeatherForecastTests : IntegrationTests
    {
        /// <summary>
        /// The serializer options.
        /// </summary>
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWeatherForecastTests"/> class.
        /// </summary>
        /// <param name="factory">The web application factory.</param>
        public CreateWeatherForecastTests(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        /// <summary>
        /// Verifies that validation passes when a valid enum is used.
        /// </summary>
        [Theory]
        [InlineData("Sunday", DayOfWeek.Sunday)]
        [InlineData("Monday", DayOfWeek.Monday)]
        [InlineData("Tuesday", DayOfWeek.Tuesday)]
        [InlineData("Wednesday", DayOfWeek.Wednesday)]
        [InlineData("Thursday", DayOfWeek.Thursday)]
        [InlineData("Friday", DayOfWeek.Friday)]
        [InlineData("Saturday", DayOfWeek.Saturday)]
        public async Task Create_WithValidEnum_ReturnsOk(string value, DayOfWeek dayOfWeek)
        {
            // Arrange
            var request = CreateRequest(value);

            // Act
            var response = await HttpClient.SendAsync(request);

            // Assert
            using var scope = new AssertionScope();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            scope.AddReportable("Content", content);

            var model = JsonSerializer.Deserialize<WeatherForecast>(content, _options);
            model.DayOfWeek.Enum.Should().Be(dayOfWeek);
        }

        /// <summary>
        /// Verifies that validation fails when an invalid enum is used.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("Foo")]
        [InlineData("sunday")]
        [InlineData("SUNDAY")]
        [InlineData("SuNdAy")]
        public async Task Create_WithInvalidEnum_ReturnsBadRequest(string value)
        {
            // Arrange
            var request = CreateRequest(value);

            // Act
            var response = await HttpClient.SendAsync(request);

            // Assert
            var message = $"Value `{value}` must be one of: Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday";
            await AssertDayOfWeekError(response, message);
        }

        /// <summary>
        /// Verifies that validation fails when an enum is not provided.
        /// </summary>
        [Fact]
        public async Task Create_WithoutEnum_ReturnsBadRequest()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "WeatherForecast");
            request.Content = new StringContent("{}");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await HttpClient.SendAsync(request);

            // Assert
            await AssertDayOfWeekError(response, $"The DayOfWeek field is required.");
        }

        /// <summary>
        /// Asserts that the day of week error in the <paramref name="response"/> has the given <paramref name="message"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="message">The expected message.</param>
        private async Task AssertDayOfWeekError(HttpResponseMessage response, string message)
        {
            using var scope = new AssertionScope();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var content = await response.Content.ReadAsStringAsync();
            scope.AddReportable("Content", content);

            var model = JsonSerializer.Deserialize<ValidationProblemDetails>(content, _options);
            model.Errors.Should().ContainKey("DayOfWeek");
            model.Errors["DayOfWeek"].Should().BeEquivalentTo(new List<string>() { message });
        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <param name="dayOfWeek">The day of the week.</param>
        /// <returns>The request.</returns>
        private HttpRequestMessage CreateRequest(string dayOfWeek)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "WeatherForecast");
            request.Content = new StringContent($"{{ \"dayOfWeek\": \"{dayOfWeek}\"}}");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return request;
        }
    }
}
