using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Woody230.AspNetCore.App.Builder.Configuration;
using Woody230.AspNetCore.App.Builder.Host;
using Woody230.AspNetCore.App.Builder.WebHost;

namespace Woody230.AspNetCore.App.Builder.Application;

/// <summary>
/// Wraps the <see cref="WebApplicationBuilder"/> as a <see cref="IWebApplicationBuilder"/>.
/// </summary>
public sealed class AspNetCoreWebApplicationBuilder : IWebApplicationBuilder
{
    private readonly WebApplicationBuilder _webApplicationBuilder;
    private readonly IConfigurationManager _configurationManager;
    private readonly IConfigureWebHostBuilder _configureWebHostBuilder;
    private readonly IConfigureHostBuilder _configureHostBuilder;

    public AspNetCoreWebApplicationBuilder(WebApplicationBuilder webApplicationBuilder)
    {
        _webApplicationBuilder = webApplicationBuilder;
        _configurationManager = new AspNetCoreConfigurationManager(webApplicationBuilder.Configuration);
        _configureWebHostBuilder = new AspNetCoreConfigureWebHostBuilder(webApplicationBuilder.WebHost);
        _configureHostBuilder = new AspNetCoreConfigureHostBuilder(webApplicationBuilder.Host);
    }

    public IWebHostEnvironment Environment => _webApplicationBuilder.Environment;

    public IServiceCollection Services => _webApplicationBuilder.Services;

    public IConfigurationManager Configuration => _configurationManager;

    public ILoggingBuilder Logging => _webApplicationBuilder.Logging;

    public IConfigureWebHostBuilder WebHost => _configureWebHostBuilder;

    public IConfigureHostBuilder Host => _configureHostBuilder;

    public IWebApplication Build() => new AspNetCoreWebApplication(_webApplicationBuilder.Build());
}
