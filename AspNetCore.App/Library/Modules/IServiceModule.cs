using Microsoft.Extensions.DependencyInjection;

namespace Woody230.AspNetCore.App.Modules;

/// <summary>
/// Represents a module that can be injected into a service collection.
/// </summary>
public interface IServiceModule
{
    /// <summary>
    /// Injects services into the collection.
    /// </summary>
    public void Apply(IServiceCollection services);
}
