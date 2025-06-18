using Microsoft.AspNetCore.Mvc.Testing;

namespace Woody230.BindableEnum.Tests.Integration;

/// <summary>
/// Represents integration tests for the <see cref="Program"/>.
/// </summary>
public abstract class IntegrationTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    /// <summary>
    /// The HTTP client.
    /// </summary>
    protected HttpClient HttpClient { get; } = factory.CreateClient();
}
