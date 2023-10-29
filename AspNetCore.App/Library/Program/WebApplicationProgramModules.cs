using Woody230.AspNetCore.App.Modules;

namespace Woody230.AspNetCore.App.Program;
public class WebApplicationProgramModules : IWebApplicationProgramModules
{
    public WebApplicationProgramModules(): this(new WebApplicationBuilderModuleCollection(), new WebApplicationModuleCollection())
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
