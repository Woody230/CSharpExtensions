using Microsoft.AspNetCore.Builder;
using System;
using System.Threading.Tasks;
using Woody230.AspNetCore.App.Builder;

namespace Woody230.AspNetCore.App.Program;


public class AspNetCoreWebApplicationProgram : IWebApplicationProgram
{
    private readonly WebApplicationOptions _options;

    public AspNetCoreWebApplicationProgram(WebApplicationOptions options, IWebApplicationProgramModules modules)
    {
        _options = options;
        Modules = modules;
        Arguments = options.Args ?? Array.Empty<string>();
    }

    public string[] Arguments { get; }

    public IWebApplicationProgramModules Modules { get; }

    public void Run()
    {
        BuildApplication().Run();
    }

    public Task RunAsync()
    {
        return BuildApplication().RunAsync();
    }

    private IWebApplication BuildApplication()
    {
        var builder = new AspNetCoreWebApplicationBuilder(WebApplication.CreateBuilder(_options));
        foreach (var module in Modules.Builder)
        {
            module.Apply(builder);
        }

        var application = builder.Build();
        foreach (var module in Modules.Application)
        {
            module.Apply(application);
        }

        return application;
    }
}
