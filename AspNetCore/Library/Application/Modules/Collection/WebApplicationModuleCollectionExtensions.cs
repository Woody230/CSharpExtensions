namespace Woody230.AspNetCore.Application.Modules.Collection;

/// <summary>
/// Represents extensions for a <see cref="IWebApplicationModuleCollection"/>
/// </summary>
public static class WebApplicationModuleCollectionExtensions
{
    /// <summary>
    /// Adds the delegated configuring of the <see cref="IWebApplication"/> as a module to the collection.
    /// </summary>
    public static TCollection Add<TCollection>(this TCollection collection, Action<IWebApplication> configure) where TCollection : IWebApplicationModuleCollection
    {
        var module = new DelegatedWebApplicationModule(configure);
        collection.Add(module);
        return collection;
    }
}
