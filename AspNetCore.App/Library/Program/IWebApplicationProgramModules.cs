using Woody230.AspNetCore.App.Modules;

namespace Woody230.AspNetCore.App.Program;
public interface IWebApplicationProgramModules
{
    public IWebApplicationBuilderModuleCollection Builder { get; }
    public IWebApplicationModuleCollection Application { get; }
}
