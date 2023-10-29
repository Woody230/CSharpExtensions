using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace Woody230.AspNetCore.Application.Builder.Host;

/// <summary>
/// Wraps a <see cref="ConfigureHostBuilder"/> as a <see cref="IConfigureHostBuilder"/>.
/// </summary>
public sealed class AspNetCoreConfigureHostBuilder : IConfigureHostBuilder
{
    private readonly IHostBuilder _hostBuilder;
    private readonly ISupportsConfigureWebHost _supportsConfigureWebHost;

    public AspNetCoreConfigureHostBuilder(ConfigureHostBuilder configureHostBuilder)
    {
        _hostBuilder = configureHostBuilder;
        _supportsConfigureWebHost = configureHostBuilder;
    }

    public IDictionary<object, object> Properties => _hostBuilder.Properties;

    public IHost Build() => _hostBuilder.Build();

    public IHostBuilder ConfigureAppConfiguration(Action<HostBuilderContext, IConfigurationBuilder> configureDelegate) => _hostBuilder.ConfigureAppConfiguration(configureDelegate);

    public IHostBuilder ConfigureContainer<TContainerBuilder>(Action<HostBuilderContext, TContainerBuilder> configureDelegate) => _hostBuilder.ConfigureContainer(configureDelegate);

    public IHostBuilder ConfigureHostConfiguration(Action<IConfigurationBuilder> configureDelegate) => _hostBuilder.ConfigureHostConfiguration(configureDelegate);

    public IHostBuilder ConfigureServices(Action<HostBuilderContext, IServiceCollection> configureDelegate) => _hostBuilder.ConfigureServices(configureDelegate);

    public IHostBuilder ConfigureWebHost(Action<IWebHostBuilder> configure, Action<WebHostBuilderOptions> configureOptions) => _supportsConfigureWebHost.ConfigureWebHost(configure, configureOptions);

    public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory) where TContainerBuilder : notnull => _hostBuilder.UseServiceProviderFactory(factory);

    public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(Func<HostBuilderContext, IServiceProviderFactory<TContainerBuilder>> factory) where TContainerBuilder : notnull => _hostBuilder.UseServiceProviderFactory(factory);
}