using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Woody230.AspNetCore.App.Application;
using Woody230.AspNetCore.App.Builder.Configuration;
using Woody230.AspNetCore.App.Builder.Host;
using Woody230.AspNetCore.App.Builder.WebHost;

namespace Woody230.AspNetCore.App.Builder;

/// <summary>
/// A builder for web applications and services.
/// </summary>
public interface IWebApplicationBuilder
{
    /// <summary>
    /// Provides information about the web hosting environment an application is running.
    /// </summary>
    public IWebHostEnvironment Environment { get; }

    /// <summary>
    /// A collection of services for the application to compose. This is useful for adding user provided or framework provided services.
    /// </summary>
    public IServiceCollection Services { get; }

    /// <summary>
    /// A collection of services for the application to compose. This is useful for adding user provided or framework provided services.
    /// </summary>
    public IConfigurationManager Configuration { get; }

    /// <summary>
    /// A collection of logging providers for the application to compose. This is useful for adding new logging providers.
    /// </summary>
    public ILoggingBuilder Logging { get; }

    /// <summary>
    /// An <see cref="IWebHostBuilder"/> for configuring server specific properties, but not building.
    /// To build after configuration, call <see cref="Build"/>.
    /// </summary>
    public IConfigureWebHostBuilder WebHost { get; }

    /// <summary>
    /// An <see cref="IHostBuilder"/> for configuring host specific properties, but not building.
    /// To build after configuration, call <see cref="Build"/>.
    /// </summary>
    public IConfigureHostBuilder Host { get; }

    /// <summary>
    /// Builds the <see cref="IWebApplication"/>.
    /// </summary>
    /// <returns>A configured <see cref="IWebApplication"/>.</returns>
    public IWebApplication Build();

}
