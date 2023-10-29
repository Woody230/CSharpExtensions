using Microsoft.AspNetCore.Hosting.Infrastructure;
using Microsoft.Extensions.Hosting;
using Woody230.AspNetCore.App.Builder.Application;

namespace Woody230.AspNetCore.App.Builder.Host;

/// <summary>
/// A non-buildable <see cref="IHostBuilder"/> for <see cref="IWebApplicationBuilder"/>.
/// Use <see cref="IWebApplicationBuilder.Build"/> to build the <see cref="IWebApplicationBuilder"/>.
/// </summary>
public interface IConfigureHostBuilder : IHostBuilder, ISupportsConfigureWebHost
{
}
