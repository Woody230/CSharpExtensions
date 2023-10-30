using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Woody230.AspNetCore.Application;

/// <summary>
/// Wraps a <see cref="WebApplication"/> as a <see cref="IWebApplication"/>.
/// </summary>
public sealed class AspNetCoreWebApplication : IWebApplication
{
    private readonly WebApplication _webApplication;
    private readonly IHost _host;
    private readonly IApplicationBuilder _applicationBuilder;
    private readonly IEndpointRouteBuilder _endpointRouteBuilder;

    public AspNetCoreWebApplication(WebApplication webApplication)
    {
        _webApplication = webApplication;
        _host = webApplication;
        _applicationBuilder = webApplication;
        _endpointRouteBuilder = webApplication;
    }

    public IServiceProvider Services => _host.Services;

    public IServiceProvider ApplicationServices { get => _applicationBuilder.ApplicationServices; set => _applicationBuilder.ApplicationServices = value; }

    public IFeatureCollection ServerFeatures => _applicationBuilder.ServerFeatures;

    public IDictionary<string, object?> Properties => _applicationBuilder.Properties;

    public IServiceProvider ServiceProvider => _endpointRouteBuilder.ServiceProvider;

    public ICollection<EndpointDataSource> DataSources => _endpointRouteBuilder.DataSources;

    public IConfiguration Configuration => _webApplication.Configuration;

    public IWebHostEnvironment Environment => _webApplication.Environment;

    public IHostApplicationLifetime Lifetime => _webApplication.Lifetime;

    public ILogger Logger => _webApplication.Logger;

    public ICollection<string> Urls => _webApplication.Urls;

    public RequestDelegate Build() => _applicationBuilder.Build();

    public IApplicationBuilder CreateApplicationBuilder() => _endpointRouteBuilder.CreateApplicationBuilder();

    public void Dispose()
    {
        _host.Dispose();
    }

    public ValueTask DisposeAsync() => _webApplication.DisposeAsync();

    public IApplicationBuilder New() => _applicationBuilder.New();

    public void Run(string? url = null)
    {
        _webApplication.Run(url);
    }

    public Task RunAsync(string? url = null) => _webApplication.RunAsync(url);

    public Task StartAsync(CancellationToken cancellationToken = default) => _host.StartAsync(cancellationToken);

    public Task StopAsync(CancellationToken cancellationToken = default) => _host.StopAsync(cancellationToken);

    public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware) => _applicationBuilder.Use(middleware);
}
