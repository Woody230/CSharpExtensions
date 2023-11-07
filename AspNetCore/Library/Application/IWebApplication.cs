using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Woody230.AspNetCore.Application;

/// <summary>
/// The web application used to configure the HTTP pipeline, and routes.
/// </summary>
public interface IWebApplication : IHost, IApplicationBuilder, IEndpointRouteBuilder, IAsyncDisposable
{
    /// <summary>
    /// Runs an application and returns a Task that only completes when the token is triggered or shutdown is triggered.
    /// </summary>
    /// <param name="url">The URL to listen to if the server hasn't been configured directly.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the entire runtime of the <see cref="WebApplication"/> from startup to shutdown.
    /// </returns>
    public Task RunAsync(string? url = null);

    /// <summary>
    /// Runs an application and block the calling thread until host shutdown.
    /// </summary>
    /// <param name="url">The URL to listen to if the server hasn't been configured directly.</param>
    public void Run(string? url = null);

    /// <summary>
    /// The application's configured <see cref="IConfiguration"/>.
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// The application's configured <see cref="IWebHostEnvironment"/>.
    /// </summary>
    public IWebHostEnvironment Environment { get; }

    /// <summary>
    /// Allows consumers to be notified of application lifetime events.
    /// </summary>
    public IHostApplicationLifetime Lifetime { get; }

    /// <summary>
    /// The default logger for the application.
    /// </summary>
    public ILogger Logger { get; }

    /// <summary>
    /// The list of URLs that the HTTP server is bound to.
    /// </summary>
    public ICollection<string> Urls { get; }
}
