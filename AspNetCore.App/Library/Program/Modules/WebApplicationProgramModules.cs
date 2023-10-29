using Woody230.AspNetCore.App.Modules;
using Woody230.AspNetCore.App.Modules.Application.Collection;
using Woody230.AspNetCore.App.Modules.Builder.Collection;

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
