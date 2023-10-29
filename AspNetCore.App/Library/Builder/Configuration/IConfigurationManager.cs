using Microsoft.Extensions.Configuration;
using System;

namespace Woody230.AspNetCore.App.Builder.Configuration;

/// <summary>
/// Configuration is mutable configuration object. It is both an <see cref="IConfigurationBuilder"/> and an <see cref="IConfigurationRoot"/>.
/// As sources are added, it updates its current view of configuration.
/// </summary>
public interface IConfigurationManager : IConfigurationBuilder, IConfigurationRoot, IDisposable
{
}
