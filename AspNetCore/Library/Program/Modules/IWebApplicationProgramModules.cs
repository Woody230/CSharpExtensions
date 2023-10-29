using Woody230.AspNetCore.Application.Builder.Modules.Collection;
using Woody230.AspNetCore.Application.Modules.Collection;

namespace Woody230.AspNetCore.Program.Modules;

/// <summary>
/// Represents the modules for building a <see cref="IWebApplicationProgram"/>.
/// </summary>
public interface IWebApplicationProgramModules
{
    public IWebApplicationBuilderModuleCollection Builder { get; }
    public IWebApplicationModuleCollection Application { get; }
}
