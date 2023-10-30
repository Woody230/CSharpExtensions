using System.Collections.Generic;

namespace Woody230.AspNetCore.Application.Modules.Collection;

/// <summary>
/// Represents a collection of <see cref="IWebApplicationModule"/>.
/// </summary>
public interface IWebApplicationModuleCollection : ICollection<IWebApplicationModule>
{
    /// <summary>
    /// Adds the module to the collection and returns the collection.
    /// </summary>
    public IWebApplicationModuleCollection Apply(IWebApplicationModule module);
}
