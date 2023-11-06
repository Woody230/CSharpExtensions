using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Woody230.BindableEnum.Tests.Integration;

/// <summary>
/// Represents integration tests for the <see cref="Program"/>.
/// </summary>
public abstract class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    /// <summary>
    /// The HTTP client.
    /// </summary>
    protected HttpClient HttpClient { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="IntegrationTests"/> class.
    /// </summary>
    /// <param name="factory">The web application factory.</param>
    protected IntegrationTests(WebApplicationFactory<Program> factory)
    {
        HttpClient = factory.CreateClient();
    }
}
