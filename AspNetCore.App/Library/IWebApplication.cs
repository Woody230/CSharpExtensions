using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Woody230.AspNetCore.App;

/// <summary>
/// The web application used to configure the HTTP pipeline, and routes.
/// </summary>
public interface IWebApplication: IHost, IApplicationBuilder, IEndpointRouteBuilder, IAsyncDisposable
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
}
