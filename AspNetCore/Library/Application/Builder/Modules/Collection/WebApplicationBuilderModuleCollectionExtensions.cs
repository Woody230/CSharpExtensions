namespace Woody230.AspNetCore.Application.Builder.Modules.Collection;

/// <summary>
/// Represents extensions for a <see cref="IWebApplicationBuilderModuleCollection"/>
/// </summary>
public static class WebApplicationBuilderModuleCollectionExtensions
{
    /// <summary>
    /// Adds the delegated configuring of the <see cref="IWebApplicationBuilder"/> as a module to the collection.
    /// </summary>
    public static TCollection Add<TCollection>(this TCollection collection, Action<IWebApplicationBuilder> configure) where TCollection: IWebApplicationBuilderModuleCollection
    {
        var module = new DelegatedWebApplicationBuilderModule(configure);
        collection.Add(module);
        return collection;
    }
}
