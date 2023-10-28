﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace Woody230.AspNetCore.App;

/// <summary>
/// Wraps the <see cref="ConfigurationManager"/> as a <see cref="IConfigurationManager"/>.
/// </summary>
public sealed class AspNetCoreConfigurationManager: IConfigurationManager
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

    public string this[string key] { get => _configurationManager[key]; set => _configurationManager[key] = value; }

    public IDictionary<string, object> Properties => _configurationBuilder.Properties;

    public IList<IConfigurationSource> Sources => _configurationBuilder.Sources;

    public IEnumerable<IConfigurationProvider> Providers => _configurationRoot.Providers;

    public IConfigurationBuilder Add(IConfigurationSource source) => _configurationBuilder.Add(source);

    public IConfigurationRoot Build() => _configurationBuilder.Build();

    public void Dispose()
    {
        _configurationManager.Dispose();
        GC.SuppressFinalize(this);
    }

    public IEnumerable<IConfigurationSection> GetChildren() => _configurationManager.GetChildren();

    public IChangeToken GetReloadToken() => _configurationRoot.GetReloadToken();

    public IConfigurationSection GetSection(string key) => _configurationManager.GetSection(key);

    public void Reload()
    {
        _configurationRoot.Reload();
    }
}
