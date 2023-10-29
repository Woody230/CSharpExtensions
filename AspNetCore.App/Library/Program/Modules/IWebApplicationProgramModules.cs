using Woody230.AspNetCore.App.Application.Builder.Modules.Collection;
using Woody230.AspNetCore.App.Application.Modules.Collection;

namespace Woody230.AspNetCore.App.Program.Modules;
public interface IWebApplicationProgramModules
{
    public IWebApplicationBuilderModuleCollection Builder { get; }
    public IWebApplicationModuleCollection Application { get; }
}
