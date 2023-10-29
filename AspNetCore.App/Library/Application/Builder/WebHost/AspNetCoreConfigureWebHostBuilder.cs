using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Woody230.AspNetCore.App.Application.Builder.WebHost;
public sealed class AspNetCoreConfigureWebHostBuilder : IConfigureWebHostBuilder
{
    private readonly IWebHostBuilder _webHostBuilder;
    private readonly ISupportsStartup _supportsStartup;

    public AspNetCoreConfigureWebHostBuilder(ConfigureWebHostBuilder configureWebHostBuilder)
    {
        _webHostBuilder = configureWebHostBuilder;
        _supportsStartup = configureWebHostBuilder;
    }

    public IWebHost Build() => _webHostBuilder.Build();

    public IWebHostBuilder Configure(Action<IApplicationBuilder> configure) => _supportsStartup.Configure(configure);

    public IWebHostBuilder Configure(Action<WebHostBuilderContext, IApplicationBuilder> configure) => _supportsStartup.Configure(configure);

    public IWebHostBuilder ConfigureAppConfiguration(Action<WebHostBuilderContext, IConfigurationBuilder> configureDelegate) => _webHostBuilder.ConfigureAppConfiguration(configureDelegate);

    public IWebHostBuilder ConfigureServices(Action<IServiceCollection> configureServices) => _webHostBuilder.ConfigureServices(configureServices);

    public IWebHostBuilder ConfigureServices(Action<WebHostBuilderContext, IServiceCollection> configureServices) => _webHostBuilder.ConfigureServices(configureServices);

    public string? GetSetting(string key) => _webHostBuilder.GetSetting(key);

    public IWebHostBuilder UseSetting(string key, string? value) => _webHostBuilder.UseSetting(key, value);

    public IWebHostBuilder UseStartup([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods)] Type startupType)
    {
        return _supportsStartup.UseStartup(startupType);
    }

    public IWebHostBuilder UseStartup<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TStartup>(Func<WebHostBuilderContext, TStartup> startupFactory)
    {
        return _supportsStartup.UseStartup(startupFactory);
    }
}
