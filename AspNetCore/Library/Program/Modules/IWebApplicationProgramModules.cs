using Woody230.AspNetCore.Application.Builder.Modules.Collection;
using Woody230.AspNetCore.Application.Modules.Collection;

namespace Woody230.AspNetCore.Program.Modules;
public interface IWebApplicationProgramModules
{
    public IWebApplicationBuilderModuleCollection Builder { get; }
    public IWebApplicationModuleCollection Application { get; }
}
