using Woody230.AspNetCore.App.Modules.Application.Collection;
using Woody230.AspNetCore.App.Modules.Builder.Collection;

namespace Woody230.AspNetCore.App.Program.Modules;
public interface IWebApplicationProgramModules
{
    public IWebApplicationBuilderModuleCollection Builder { get; }
    public IWebApplicationModuleCollection Application { get; }
}
