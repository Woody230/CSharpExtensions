using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace Woody230.AspNetCore.App.Builder.Configuration;

/// <summary>
/// Wraps the <see cref="ConfigurationManager"/> as a <see cref="IConfigurationManager"/>.
/// </summary>
public sealed class AspNetCoreConfigurationManager : IConfigurationManager
{
    private readonly ConfigurationManager _configurationManager;
    private readonly IConfigurationBuilder _configurationBuilder;
    private readonly IConfigurationRoot _configurationRoot;

    public AspNetCoreConfigurationManager(ConfigurationManager configurationManager)
    {
        _configurationManager = configurationManager;
        _configurationBuilder = configurationManager;
        _configurationRoot = configurationManager;
    }

    public string this[string key] { get => _configurationRoot[key]; set => _configurationRoot[key] = value; }

    public IDictionary<string, object> Properties => _configurationBuilder.Properties;

    public IList<IConfigurationSource> Sources => _configurationBuilder.Sources;

    public IEnumerable<IConfigurationProvider> Providers => _configurationRoot.Providers;

    public IConfigurationBuilder Add(IConfigurationSource source) => _configurationBuilder.Add(source);

    public IConfigurationRoot Build() => _configurationBuilder.Build();

    public void Dispose()
    {
        _configurationManager.Dispose();
    }

    public IEnumerable<IConfigurationSection> GetChildren() => _configurationRoot.GetChildren();

    public IChangeToken GetReloadToken() => _configurationRoot.GetReloadToken();

    public IConfigurationSection GetSection(string key) => _configurationRoot.GetSection(key);

    public void Reload()
    {
        _configurationRoot.Reload();
    }
}
