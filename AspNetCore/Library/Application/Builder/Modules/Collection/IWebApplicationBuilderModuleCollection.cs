using System.Collections.Generic;

namespace Woody230.AspNetCore.Application.Builder.Modules.Collection;

/// <summary>
/// Represents a collection of <see cref="IWebApplicationBuilderModule"/>.
/// </summary>
public interface IWebApplicationBuilderModuleCollection : ICollection<IWebApplicationBuilderModule>
{
}
