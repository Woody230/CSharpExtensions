using Woody230.AspNetCore.App.Application.Builder.Modules.Collection;
using Woody230.AspNetCore.App.Application.Modules.Collection;

namespace Woody230.AspNetCore.App.Program.Modules;
public class WebApplicationProgramModules : IWebApplicationProgramModules
{
    public WebApplicationProgramModules() : this(new WebApplicationBuilderModuleCollection(), new WebApplicationModuleCollection())
    {
    }

    public WebApplicationProgramModules(IWebApplicationBuilderModuleCollection builderModules, IWebApplicationModuleCollection applicationModules)
    {
        Builder = builderModules;
        Application = applicationModules;
    }

    public IWebApplicationBuilderModuleCollection Builder { get; }

    public IWebApplicationModuleCollection Application { get; }
}
