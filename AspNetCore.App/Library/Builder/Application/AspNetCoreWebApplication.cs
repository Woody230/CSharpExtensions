using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Woody230.AspNetCore.App.Builder.Application;

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
